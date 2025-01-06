using System;
using System.Collections.Generic;

namespace YourNamespace;

public class DrawTableClass
{
     readonly int[] maxLength;
     readonly List<object[]> rows;
     readonly string[] _column;
     int countLength;

    public DrawTableClass(params string[] columns)
    {
        countLength = 0;
        _column = columns;
        maxLength = new int[columns.Length];
        rows = new List<object[]>();
        InitializeColumnLengths(columns);
    }

    private void InitializeColumnLengths(string[] columns)
    {
        for (var i = 0; i < columns.Length; i++)
        {
            maxLength[i] = columns[i].Length;
        }
    }

    public void AddRow(params object[] rowData)
    {
        if (rowData.Length != _column.Length)
        {
            throw new ArgumentException("Row data must match the number of columns.");
        }

        rows.Add(rowData);

        for (var i = 0; i < rowData.Length; i++)
        {
            maxLength[i] = Math.Max(maxLength[i], rowData[i].ToString().Length);
        }
    }

    public void Draw()
    {
        countLength=rows.Count.ToString().Length;
        DrawHeaders();
        DrawAllRows();
    }

    private void DrawHeaders()
    {
        Console.Write($"{"#".PadRight(countLength)} | ");
        for (var i = 0; i < _column.Length; i++)
        {
            Console.Write($"{_column[i].PadRight(maxLength[i])} | ");
        }
        Console.WriteLine();

        for (var i = 0; i < _column.Length; i++)
        {
            Console.Write(new string('-', maxLength[i]) + "---");
        }
        Console.WriteLine();
    }

    private void DrawAllRows()
    {
        var count = 1;
        foreach (var row in rows)
        {
            Console.Write($"{count++.ToString().PadRight(countLength)} | ");
            for (var i = 0; i < row.Length; i++)
            {
                Console.Write($"{row[i].ToString().PadRight(maxLength[i])} | ");
            }
            Console.WriteLine();
        }
    }
}
