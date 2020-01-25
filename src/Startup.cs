using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using Csandra.game_vault.wasm.App.Data;

namespace game_vault.wasm
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<GameVaultDataService>();
            services.AddSingleton<SessionService>();
            services.AddScoped<DialogService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
