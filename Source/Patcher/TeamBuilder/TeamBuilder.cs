using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD.Patcher;
public class TeamBuilder
{
    private int _playersCount;
    public int PlayersCount
    {
        get { return _playersCount; }
        set { _playersCount = value; }
    }
    
    private int _teamsCount;
    public int TeamsCount
    {
        get { return _teamsCount; }
        set { _teamsCount = value; }
    }
    public TeamBuilder()
    { }

    // должен знать о каждом конкретном экземпляре команды.

    // должен получать инфу об изменении числа игроков в каждом конкретном экземпляре и отправлять в них ответную.
}
