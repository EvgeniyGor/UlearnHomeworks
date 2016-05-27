using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates.Classes
{
    public class SpreadsheetEngine : IObservable<SpreadsheetEngine>
    {
        private readonly List<IObserver<SpreadsheetEngine>> _observers;

        private readonly List<List<int>> _table;

        public SpreadsheetEngine(int tableWidth, int tableHeight)
        {
            _observers = new List<IObserver<SpreadsheetEngine>>();

            TableHeight = tableHeight;
            TableWidth = tableWidth;

            _table = new List<List<int>>();
            for (int i = 0; i < TableHeight; ++i)
            {
                _table[i] = Enumerable.Repeat(0, TableWidth).ToList();
            }
        }

        public int TableHeight { get; private set; }
        public int TableWidth { get; private set; }

        public IDisposable Subscribe(IObserver<SpreadsheetEngine> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new SpreadsheetEngineUnsubscriber(observer, _observers);
        }

        public void Put(int row, int column, int value)
        {
            if (!CheckRow(row))
            {
                throw new ArgumentOutOfRangeException($"{ nameof(row) } is out of range");
            }

            if (!CheckColumn(column))
            {
                throw new ArgumentOutOfRangeException($"{ nameof(column) } is out of range");
            }

            _table[column][row] = value;
            NotifyAll();
        }

        public void InsertRow(int rowIndex)
        {
            if (!CheckRow(rowIndex))
            {
                throw new ArgumentOutOfRangeException($"{ nameof(rowIndex) } is out of range");
            }
            _table.Insert(rowIndex, new List<int>());
            TableHeight++;
            NotifyAll();
        }

        public void InsertColumn(int columnIndex)
        {
            if (!CheckColumn(columnIndex))
            {
                throw new ArgumentOutOfRangeException($"{ nameof(columnIndex) } is out of range");
            }
            for (int i = 0; i < TableHeight; ++i)
            {
                _table[i].Insert(columnIndex, 0);
            }
            TableWidth++;
            NotifyAll();            
        }

        public int Get(int row, int column)
        {
            if (!CheckRow(row))
            {
                throw new ArgumentOutOfRangeException($"{ nameof(row) } is out of range");
            }

            if (!CheckColumn(column))
            {
                throw new ArgumentOutOfRangeException($"{ nameof(column) } is out of range");
            }

            var result = _table[column][row];
            NotifyAll();
            return result;
        }

        private bool CheckRow(int row)
        {
            return row < 0 || row > TableWidth;
        }

        private bool CheckColumn(int column)
        {
            return column < 0 || column > TableHeight;
        }

        private void NotifyAll()
        {
            _observers.ForEach(i => i.OnNext(this));
        }
    }
}