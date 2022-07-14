using System.Text;

namespace com.opusmagus.wu.simple;
public class ConsoleDraw {
    private const int MapW = 50;
    private const int MapH = 50;

    StringBuilder sb = new(200);
    long counter = 0;
    string HorizontalLine = new('-', MapW);

    private void PrintMap(Map map)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"Frame#: {counter++}");
        Console.WriteLine("    +" + HorizontalLine + "+");

        for (int y = 0; y < MapH; ++y)
        {
            sb.Clear();
            sb.Append($"{y:00}> |");
            for (int x = 0; x < MapW; ++x)
            {
                var mapObj = map.map[x, y];
                if (mapObj == null)
                {
                    sb.Append(' ');
                    continue;
                }
                //sb.Append(mapObj.visual);
                sb.Append('*');
            }
            sb.Append('|');
            Console.WriteLine(sb.ToString());
        }
        Console.WriteLine("    +" + HorizontalLine + "+");
    }
}