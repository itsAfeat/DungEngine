using System.Text.RegularExpressions;
using DungEngine.Entity;
using DungEngine.Misc;

namespace DungEngine.Managers
{
    public partial class LevelManager
    {
        private readonly List<Level> _levels = [];
        private Level _currLevel = null!;

        public LevelManager(string levelPath)
        {
            // Mayhaps, one should make a level designer first, saving the data
            // first, will make the reading logic part way easier, I think B^)
            return;
            /* DLF file syntax...
            * Header[levelId::nextLevelId] 
            *        = 0::1
            * -- <- New section marker
            * Color options [x(m,p,i,e,n)=fore-;background]
            *        = x=15;0
            * --
            * Item[i(id);name;amount;attribute;type;description?]
            *        = ix;Smørkniv;1;2;0000100;En helt almindelig kniv
            * Enemy[e(id);name;health;damage;defense]
            *        = ex;Slem fyr;20;3;10
            * NPC[n(id);name;health;damage;defense;dialog?]
            *        = nx;Karl Smart;1;3;???
            * --
            * Map    = ###############
            *          # e1   #     # #
            *          # ##  # ### # #
            *          #i2#       #i0# #
            *          ### ### ### # #
            *          #         # e0 #
            *          ##### # ##### #
            *          #   # #    n0# #
            *          # # # # ##### #
            *          #i1#      x# #s#
            *          ########### ###
            * ---- <- New level marker
            */

            // A bunch of variables for the Level
            int lvlId, nxtId;
            Vec2D? playerStart = null;
            Color mapColor, plyColor, itmColor, enmColor, npcColor;

            Dictionary<Vec2D, Item> items = [];
            Dictionary<Vec2D, IEntity> entities = [];
            List<char[]> map = [];

            // Read & parse the map file
            string[] mapFileContent = IO.ReadFile(levelPath);
            int j = 0;
            for (int i = 0; i < mapFileContent.Length; i++)
            {
                string? line = mapFileContent[i];
                if (line != null)
                {
                    if (line.Trim() == "--")
                    {
                        j++;
                        continue;
                    }
                    if (line.Trim() == "----")
                    {
                        _levels.Add(
                            new(playerStart ?? new(0,0),
                            Mather.To2DArray(map),
                            items, entities)
                        );

                        j = 0;
                        continue;
                    }

                    switch (j)
                    {
                        case 0: // Level ID
                            string[] lineArr = line.Split("::");
                            lvlId = int.Parse(lineArr[1]);
                            nxtId = int.Parse(lineArr[2]);
                            j++;
                            continue;
                        case 1: // Color mapping
                            ConsoleColor[] colorArr = (ConsoleColor[])line.Split('=')[1].Split(';').Select(c => (ConsoleColor)int.Parse(c));
                            Color color = new(colorArr[0], colorArr[1]);

                            switch (line[0])
                            {
                                case 'm':
                                    mapColor = color;
                                    break;
                                case 'p':
                                    plyColor = color;
                                    break;
                                case 'i':
                                    itmColor = color;
                                    break;
                                case 'e':
                                    enmColor = color;
                                    break;
                                case 'n':
                                    npcColor = color;
                                    break;
                            }
                            break;
                        case 2: // Items & entities
                            // Do nothing for now
                            break;
                        case 3: // The 2D char map
                        default:
                            int y = j - 3;
                            int x;

                            if (playerStart == null)
                            {
                                if ((x = line.IndexOf('s')) != -1)
                                { playerStart = new(x, y); }
                            }

                            if ((x = line.IndexOf('i')) != -1)
                            {
                                // pis og lort
                            }

                            line = ItemRegex().Replace(line, "*");
                            line = EnemyRegex().Replace(line, "E");
                            line = NpcRegex().Replace(line, "N");
                            line = line.Replace('x', ' '); // Remove the end point for now

                            map.Add([.. line]);
                            j++;
                            break;
                    }
                }
            }
        }

        [GeneratedRegex(@"i\d+")]
        private static partial Regex ItemRegex();
        [GeneratedRegex(@"e\d+")]
        private static partial Regex EnemyRegex();
        [GeneratedRegex(@"n\d+")]
        private static partial Regex NpcRegex();
    }
}