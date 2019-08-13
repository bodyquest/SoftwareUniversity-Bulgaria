using System;
using System.Collections.Generic;
using System.Text;

public class Area
{
    public int Size { get; set; }
    public int TopLeftRow { get; set; }
    public int TopLeftCol { get; set; }

    public Area(int topLeftRow, int topLeftCol, int size)
    {
        TopLeftRow = topLeftRow;
        TopLeftCol = topLeftCol;
        Size = size;
    }
}
