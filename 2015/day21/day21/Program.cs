using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day21
{
    class Program
    {
        static void Main(string[] args)
        {
            var bossHp = 104;
            var bossDmg = 8;
            var bossArmor = 1;

            var playerHp = 100;
            var playerDmg = 7;
            var playerArmor = 2;

            // +3 dmg ring (100), +2 armor ring (40), +4 weap (8)
            // 148

            Console.WriteLine(PlayerWin(bossHp, bossDmg, bossArmor, playerHp, playerDmg, playerArmor));

            
        }

        static bool PlayerWin(int bossHp, int bossDmg, int bossArmor, int playerHp, int playerDmg, int playerArmor)
        {
            while (bossHp > 0 && playerHp > 0)
            {
                int dmg = (playerDmg - bossArmor);

                if (dmg < 1)
                    dmg = 1;

                bossHp -= dmg;

                if (bossHp <= 0)
                    break;

                dmg = bossDmg - playerArmor;

                if (dmg < 1)
                    dmg = 1;

                playerHp -= dmg;
            }

            Console.WriteLine("Player: " + playerHp);
            Console.WriteLine("Boss: " + bossHp);
            
            return playerHp > 0;
        }
    }
}
