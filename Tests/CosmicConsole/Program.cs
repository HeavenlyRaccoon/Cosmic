using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;
namespace CosmicConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Prof();
            Task.WaitAll(Prof());
        }

        public static async void Mus()
        {
            
        }

        public static async Task Prof()
        {
            var config = SpotifyClientConfig.CreateDefault();

            var request = new ClientCredentialsRequest("e38f5549120e4f7885ed1472dc58adb6", "0e255d6f56d9433da52bfab4e8e3cf4b");
            var response = new OAuthClient(config).RequestToken(request);

           var spotify = new SpotifyClient(config.WithToken(response.Result.AccessToken));
            var song = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Track, "Талия"));
            await foreach(var i in spotify.Paginate(song.Tracks, (s) => s.Tracks)){
                Console.WriteLine(i.Name);
            }
            

            //Console.WriteLine(song);
        }
    }
}
