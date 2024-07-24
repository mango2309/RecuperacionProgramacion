using RecuperacionProgramacion.Models;
using RecuperacionProgramacion.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperacionProgramacion.ViewModels
{
    public class LocalCharactersViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<Character> LocalCharacters { get; }
        public Command LoadLocalCharactersCommand { get; }

        public LocalCharactersViewModel()
        {
            _databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "characters.db3"));
            LocalCharacters = new ObservableCollection<Character>();
            LoadLocalCharactersCommand = new Command(async () => await LoadLocalCharactersAsync());
        }

        private async Task LoadLocalCharactersAsync()
        {
            LocalCharacters.Clear();
            var characters = await _databaseService.GetCharactersAsync();
            foreach (var character in characters)
            {
                LocalCharacters.Add(character);
            }
        }

        // Implementar INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}
