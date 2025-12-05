using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B
{
    public interface IPlayable
    {
        void StartGame();
        void PauseGame();
        int GetPlayTime();
    }
}