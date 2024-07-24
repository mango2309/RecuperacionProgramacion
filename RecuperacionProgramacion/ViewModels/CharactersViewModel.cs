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
    public class CharactersViewModel : INotifyPropertyChanged
    {
        private readonly NarutoApiService _apiService;
        private readonly DatabaseService _databaseService;

        public ObservableCollection<Character> Characters { get; }
        public Command LoadCharactersCommand { get; }
        public Command<Character> SaveCharacterCommand { get; }

        public CharactersViewModel()
        {
            _apiService = new NarutoApiService();
            _databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "characters.db3"));
            Characters = new ObservableCollection<Character>();
            LoadCharactersCommand = new Command(async () => await LoadCharactersAsync());
            SaveCharacterCommand = new Command<Character>(async (character) => await SaveCharacterAsync(character));
        }

        private async Task LoadCharactersAsync()
        {
            Characters.Clear();
            var characters = await _apiService.GetCharactersAsync();
            foreach (var character in characters)
            {
                Characters.Add(character);
            }
        }

        private async Task SaveCharacterAsync(Character character)
        {
            await _databaseService.SaveCharacterAsync(character);
        }

        // Implementar INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}
