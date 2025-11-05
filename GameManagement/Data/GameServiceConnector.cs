using GameManagement.Data.Models;
using System.Collections.Generic;

namespace GameManagement.Data
{
    public class GameServiceConnector
    {
        HttpClient httpClient;
        private readonly string endpoint = "http://localhost:5181/";
        public GameServiceConnector()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(endpoint);
        }

        public async Task<List<Game>> GetGameAsync() 
        {
            HttpResponseMessage response = await httpClient.GetAsync("api/game");
            List<Game> games = new List<Game>();
            if (response.IsSuccessStatusCode) 
            {
               games = await response.Content.ReadFromJsonAsync<List<Game>>();
            }

            return games;
        }

        public async Task<Game> GetGameAsync(Guid id) 
        {
            HttpResponseMessage response = await httpClient.GetAsync($"api/game/{id}");
            
            if (response.IsSuccessStatusCode) 
            {
                Game game = await response.Content.ReadFromJsonAsync<Game>();
                return game;
            }
            return new Game() {Name = null };
        }

        public async Task<bool> UpdateGameAsync(Guid id, GameDTO gameDTO) 
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync($"api/game/{id}", gameDTO);

            if (response.IsSuccessStatusCode) 
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteGameAsync(Guid id) 
        {
            HttpResponseMessage response = await httpClient.DeleteAsync($"api/game/{id}");
            if (response.IsSuccessStatusCode) 
            {
                return true;
            }
            return false;
        }
    }
}
