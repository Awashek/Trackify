﻿using Microsoft.Extensions.Logging;
using PersonalExpenseTracking.Models;
using PersonalExpenseTracking.Services;
using PersonalExpenseTracking.Services.Interface;


namespace PersonalExpenseTracking;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

        //Register services 
        
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ITransactionService, TransactionService>();
        builder.Services.AddScoped<IDebtService, DebtService>();
        builder.Services.AddScoped<ITagService, TagService>();
        builder.Services.AddScoped<GlobalState>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
