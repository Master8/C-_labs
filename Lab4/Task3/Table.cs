using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Table : IObservable<Message>
    {
        private List<IObserver<Message>> observers;

        private List<List<int>> matrix;

        public int[][] CurrentState
        {
            get
            {
                int[][] currentState = new int[matrix.Count()][];

                for (int i = 0; i < matrix.Count(); i++)                
                    currentState[i] = matrix[i].ToArray();

                return currentState;
            }
        }

        public Table()
        {
            this.observers = new List<IObserver<Message>>();
            this.matrix = new List<List<int>>();
        }

        public void Put(int row, int column, int value)
        {
            if (matrix.Count() > row)
            {
                List<int> currentRow = matrix[row];

                if (currentRow.Count() > column)
                {
                    currentRow[column] = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value of column!");
                } 
            }
            else
            {
                throw new ArgumentException("Incorrect value of row!");
            }

            NotifyObservers(Message.PUT);
        }

        public void InsertRow(int rowIndex)
        {
            matrix.Insert(rowIndex, matrix.Count() > 0 ? new List<int>(matrix[0].Count()) : new List<int>());
            NotifyObservers(Message.INSERT_ROW);
        }

        public void InsertColumn(int columnIndex)
        {
            foreach (List<int> row in matrix)
            {
                row.Insert(columnIndex, 0);
            }
            NotifyObservers(Message.INSERT_COLUMN);
        }

        public int Get(int row, int column)
        {
            if (matrix.Count() > row)
            {
                List<int> currentRow = matrix[row];

                if (currentRow.Count() > column)
                {
                    NotifyObservers(Message.GET);
                    return currentRow[column];
                }
                else
                {
                    throw new ArgumentException("Incorrect value of column!");
                }
            }
            else
            {
                throw new ArgumentException("Incorrect value of row!");
            }
        }

        public IDisposable Subscribe(IObserver<Message> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Message>> _observers;
            private IObserver<Message> _observer;

            public Unsubscriber(List<IObserver<Message>> observers, IObserver<Message> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        private void NotifyObservers(Message message)
        {
            foreach (IObserver<Message> observer in observers)
                observer.OnNext(message);
        }
    }
}
