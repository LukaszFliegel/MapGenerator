using System;

namespace MapGeneration.Logic
{
    public class MapGenerator : IMapGenerator
    {
        private readonly Random random = new Random();

        public Map Create(int length, int width, int height)
        {
            Map map = new Map(length, width, height);

            return map;
        }

        //public MapTile[][] Create(int length, int width)
        //{
        //    var map = new MapTile[length][];

        //    for (int i = 0; i < length; i++)
        //    {
        //        map[i] = new MapTile[width];
        //    }

        //    for (int i = 0; i < length; i++)
        //    {
        //        for (int j = 0; j < width; j++)
        //        {
        //            map[i][j] = MapTile.Grass;
        //        }
        //    }

        //    GenerateRiver(map);

        //    return map;
        //}

        //private void GenerateRiver(MapTile[][] map)
        //{
        //    var riverStartSide = random.Next(3);
        //    var riverEndSide = -1;
        //    while ((riverEndSide = random.Next(3)) == riverStartSide)
        //        riverEndSide = random.Next(3);

        //    Console.WriteLine($"River starts at the {(MapSides)riverStartSide} side");
        //    Console.WriteLine($"River ends at the {(MapSides)riverEndSide} side");

        //    var riverGoesThrougQuarter = random.Next(3);
        //    Console.WriteLine($"River goes through {(MapQuarters)riverGoesThrougQuarter} quarter");
        //}
    }

    public class Map
    {
        private readonly int _sizeX;
        private readonly int _sizeZ;
        private readonly int _sizeH;

        private MapTile[][][] _tiles;

        public Map(int sizeX, int sizeZ, int sizeH)
        {
            _sizeX = sizeX;
            _sizeZ = sizeZ;
            _sizeH = sizeH;

            _tiles = new MapTile[sizeX][][];

            for (int x = 0; x < sizeX; x++)
            {
                _tiles[x] = new MapTile[sizeZ][];

                for (int z = 0; z < sizeZ; z++)
                {
                    _tiles[x][z] = new MapTile[sizeH];
                }
            }
        }

        public MapTile this[int x, int z, int h]
        {
            get {
                x = x < 0 ? 0 : x;
                z = z < 0 ? 0 : z;
                h = h < 0 ? 0 : h;

                x = x >= _sizeX ? _sizeX - 1 : x;
                z = z >= _sizeZ ? _sizeZ - 1 : z;
                h = h >= _sizeH ? _sizeH - 1 : h;

                return _tiles[x][z][h];
            }
        }
    }

    public enum MapTile
    {
        Grass = '.',
        Stone = 'M',
        Water = '~',        
        Tree = 'o',
    }

    public enum MapSides
    {
        Top = 0,
        Right = 1,
        Down = 2,
        Left = 3,
    }

    public enum MapQuarters
    {
        TopRight = 0,
        DownRight = 1,
        LeftDown = 2,
        LeftUp = 3,
    }
}
