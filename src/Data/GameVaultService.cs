using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Csandra.game_vault.wasm.App.Data
{
    public class GameVaultDataService
    {   
        private readonly string apiUri = "@@@API_ACCESS@@@";

        public async Task<List<GameVaultData>> GetGames (){
            try{
                using(var httpClient = new HttpClient()){
                    var response = await  httpClient.GetAsync($"{apiUri}");
                    if(response.IsSuccessStatusCode){
                        var json = await response.Content.ReadAsStringAsync();
                        
                        var comics = (IEnumerable<GameVaultData>)JsonConvert.DeserializeObject(json, typeof(IEnumerable<GameVaultData>));
                        return comics.ToList();
                    }
                    else{
                        throw new Exception(await response.Content.ReadAsStringAsync());
                    }
                   
                }
           }
           catch(Exception ex){
               Console.WriteLine(ex.Message);
               return new List<GameVaultData>();
           }
        }

        
        public async void Save(GameVaultData data, string client=""){
            try{
                if(string.IsNullOrWhiteSpace(client))
                    throw new UnauthorizedAccessException();
                 using(var httpClient = new HttpClient()){
                    var json = JsonConvert.SerializeObject(
                        new {
                            Client = client,
                            Data = data
                        });
                    StringContent content = new StringContent(json);
                    var response = await  httpClient.PostAsync($"{apiUri}", content);
                    if(!response.IsSuccessStatusCode){
                        throw new Exception(await response.Content.ReadAsStringAsync());
                    }
                }
           }
           catch(Exception ex){
               Console.WriteLine(ex.Message);
           }
        }

        
        internal string GetAPI()=> apiUri;
    }
}