using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RIddles
{
    internal class MainWindowViewModel: ViewModel
    {
        private List<Riddle> Riddles;
        private Riddle _Selected_Riddle;
        private string _Answer;

        public string Answer
        {
            get => _Answer;
            set => Set(ref _Answer, value);
        }
        public Riddle Selected_Riddle
        {
            get => _Selected_Riddle;
            set => Set(ref _Selected_Riddle, value);
        }

        public ICommand AnswerCommand { get; }

        private void OnAnswerCommandExecuted(object p)
        {
            if (Selected_Riddle.Answer == p?.ToString())
            {
                p.ToString();
                int rnd = new Random().Next(0, 4);
                Selected_Riddle = Riddles[rnd];
            }
        }

        private bool CanAnswerCommandExecute(object p)
        {
            return true;
        }
        public MainWindowViewModel()
        {
            AnswerCommand = new LamdaCommand(OnAnswerCommandExecuted, CanAnswerCommandExecute);

            Riddles = new List<Riddle>()
            {
                new Riddle{Text="Зимой и летом одним цветом", Answer="Елка"},
                new Riddle{Text="Не лает, не кусает, а в дом не пускает", Answer="Замок"},
                new Riddle{Text="Сидит дед, в сто шуб одет", Answer="Лук"},
                new Riddle{Text="Висит груша, нельзя скушать", Answer="Лампа"},
            };

            int rnd = new Random().Next(0, Riddles.Count());
            Selected_Riddle = Riddles[rnd];
        }
    }
}
