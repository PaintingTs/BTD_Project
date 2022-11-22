using System.Text.RegularExpressions;

namespace Automations;

public class BankInfoDetector
{
    string output_info = "BTD_GENERATED_BANKS_INFO = \n{\n";

    private List<string> _possibleBanks = new List<string>()
    {
        "BankCrypt", "BankPyramid", "BankMagiVault", "BankDragonUtopia",
        "BankElementalsStockpile", "BankDemolish", "BankUnkempt", "BankDwarvenTreasure",
        "BankBloodTemple", "BankTreantThicket", "BankGargoyleStonevault", "BankSunkenTemple",
        "BankNagaTemple"
    };

    public void Run()
    {
        Regex _mainRegex = new Regex("<Banks.*?>([^|]*)<\\/Banks>", RegexOptions.Singleline);
        //
        string _mainFile = File.ReadAllText("D:\\Users\\pgn\\source\\repos\\Automations\\DefaultStats.xdb");
        Match _banksMatch = _mainRegex.Match(_mainFile);
        if (_banksMatch.Success)
        {
            string _allBanksInfo = _banksMatch.Groups[1].ToString();
            foreach (string _bank in _possibleBanks)
            {
                Regex _bankRegex = new Regex("<" + _bank + ".*?>([^|]*)<\\/" + _bank + ">", RegexOptions.Singleline);
                Match _bankMatch = _bankRegex.Match(_allBanksInfo);
                if (_bankMatch.Success)
                {
                    Console.WriteLine("Analyzing bank " + _bank);
                    output_info = output_info + "\t" + _bank + " = \n\t{\n";
                    string _bankInfo = _bankMatch.Groups[1].ToString();
                    AnalyzeBank(_bankInfo);
                    output_info += "\t},\n";
                }
            }
        }
        output_info += "}";
        File.WriteAllText("D:\\Users\\pgn\\source\\repos\\Automations\\bank_info.lua", output_info);
    }

    private void AnalyzeBank(string bank_info)
    {
        Regex _variantsRegex = new Regex("<Variants.*?>([^|]*)<\\/Variants>", RegexOptions.Singleline);
        Regex _variantRegex = new Regex("<Item.*?>(.*?)<\\/RandomSpellsLevel>", RegexOptions.Singleline);
        int _variantsCount = 0;

        Match _bankVariantsMatch = _variantsRegex.Match(bank_info);
        if(_bankVariantsMatch.Success)
        {
            string _bankVariants = _bankVariantsMatch.Groups[1].ToString();
            foreach(Match _bankVariantMatch in _variantRegex.Matches(_bankVariants))
            {
                if(_bankVariantMatch.Success)
                {
                    _variantsCount++;
                    Console.WriteLine("Variant " + _variantsCount.ToString());
                    output_info = output_info + "\t\t[" + _variantsCount.ToString() + "] = \n\t\t{\n";
                    string _bankVariant = _bankVariantMatch.Groups[0].ToString();
                    AnalyzeVariant(_bankVariant);
                    output_info += "\t\t},\n";
                }
            }
        }
    }

    private void AnalyzeVariant(string variant_info)
    {
        Regex _variantChanceRegex = new Regex("<ChanceOfVariant>" + "(.*)" + "</ChanceOfVariant>");
        Regex _creaturesRegex = new Regex("<Creatures.*?>([^|]*)<\\/Creatures>", RegexOptions.Singleline);
        Regex _itemRegex = new Regex("<Item.*?>(.*?)<\\/Item>", RegexOptions.Singleline);

        Match _variantChanceMatch = _variantChanceRegex.Match(variant_info);
        if(_variantChanceMatch.Success)
        {
            string _variantChance = _variantChanceMatch.Groups[1].ToString();
            output_info = output_info + "\t\t\tChance = " + _variantChance + ",\n";
            Console.WriteLine("Chance: " + _variantChance);
        }
        Match _creaturesMatch = _creaturesRegex.Match(variant_info);
        if(_creaturesMatch.Success)
        {
            string _creaturesInfo = _creaturesMatch.Groups[1].ToString();
            int _creatureInfoVariantsCount = 0;
            output_info = output_info + "\t\t\tCreatures = \n\t\t\t{\n";
            foreach(Match _creatureInfoMatch in _itemRegex.Matches(_creaturesInfo))
            {
                if(_creatureInfoMatch.Success)
                {
                    _creatureInfoVariantsCount++;
                    Console.WriteLine("Checking creature's variant " + _creatureInfoVariantsCount.ToString());
                    string _creatureInfo = _creatureInfoMatch.Groups[1].ToString();
                    output_info += "\t\t\t\t{\n";
                    AnalyzeCreatureInfo(_creatureInfo);
                    output_info += "\t\t\t\t},\n";
                }
            }
            output_info += "\t\t\t}\n";
        }

    }

    private void AnalyzeCreatureInfo(string creature_info)
    {
        Regex _firstCreatureRegex = new Regex("<Creature1>" + "(.*)" + "</Creature1>");
        Regex _secondCreatureRegex = new Regex("<Creature2>" + "(.*)" + "</Creature2>");
        Regex _firstCreatureChanceRegex = new Regex("<ChanceOfCreature1>" + "(.*)" + "</ChanceOfCreature1>");
        Regex _secondCreatureChanceRegex = new Regex("<ChanceOfCreature2>" + "(.*)" + "</ChanceOfCreature2>");
        //
        Regex _firstCreatureMinCountRegex = new Regex("<MinCount1>" + "(.*)" + "</MinCount1>");
        Regex _firstCreatureMaxCountRegex = new Regex("<MaxCount1>" + "(.*)" + "</MaxCount1>");
        Regex _secondCreatureMinCountRegex = new Regex("<MinCount2>" + "(.*)" + "</MinCount2>");
        Regex _secondCreatureMaxCountRegex = new Regex("<MaxCount2>" + "(.*)" + "</MaxCount2>");

        string _firstCreatureType = _firstCreatureRegex.Match(creature_info).Groups[1].ToString();
        string _secondCreatureType = _secondCreatureRegex.Match(creature_info).Groups[1].ToString();
        string _firstCreatureChance = _firstCreatureChanceRegex.Match(creature_info).Groups[1].ToString();
        string _secondCreatureChance = _secondCreatureChanceRegex.Match(creature_info).Groups[1].ToString();

        string _firstCreatureMinCount = _firstCreatureMinCountRegex.Match(creature_info).Groups[1].ToString();
        string _firstCreatureMaxCount = _firstCreatureMaxCountRegex.Match(creature_info).Groups[1].ToString();
        string _secondCreatureMinCount = _secondCreatureMinCountRegex.Match(creature_info).Groups[1].ToString();
        string _secondCreatureMaxCount = _secondCreatureMaxCountRegex.Match(creature_info).Groups[1].ToString();

        output_info = output_info + "\t\t\t\t\t[" + _firstCreatureType + "] = {chance = " + _firstCreatureChance + ", count_min = " + _firstCreatureMinCount + ", count_max = " + _firstCreatureMaxCount + "},\n";
        output_info = output_info + "\t\t\t\t\t[" + _secondCreatureType + "] = {chance = " + _secondCreatureChance + ", count_min = " + _secondCreatureMinCount + ", count_max = " + _secondCreatureMaxCount + "},\n";
        Console.WriteLine("First creature: " + _firstCreatureType + " with chance " + _firstCreatureChance + " and counts " + _firstCreatureMinCount + " - " + _firstCreatureMaxCount);
        Console.WriteLine("Second creature: " + _secondCreatureType + " with chance " + _secondCreatureChance + " and counts " + _secondCreatureMinCount + " - " + _secondCreatureMaxCount);
    }
}
