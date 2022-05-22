using System;
using System.Collections.Generic;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using DevPlays_WinUI3.Contracts.Services;
using DevPlays_WinUI3.ViewModels;
using DevPlays_WinUI3.Views;

using Microsoft.UI.Xaml.Controls;

namespace DevPlays_WinUI3.Services
{
    public class PageService : IPageService
    {
        private readonly Dictionary<string, Type> _pages = new Dictionary<string, Type>();

        public PageService()
        {
            Configure<MainViewModel, MainPage>();
            Configure<NumberBaseViewModel, NumberBasePage>();
            Configure<NumberBaseDetailViewModel, NumberBaseDetailPage>();
            Configure<SQLFormatterViewModel, SQLFormatterPage>();
            Configure<SQLFormatterDetailViewModel, SQLFormatterDetailPage>();
            Configure<XMLFormatterViewModel, XMLFormatterPage>();
            Configure<XMLFormatterDetailViewModel, XMLFormatterDetailPage>();
            Configure<JSONFormatterViewModel, JSONFormatterPage>();
            Configure<JSONFormatterDetailViewModel, JSONFormatterDetailPage>();
            Configure<Base64ConverterViewModel, Base64ConverterPage>();
            Configure<Base64ConverterDetailViewModel, Base64ConverterDetailPage>();
            Configure<GZIPConverterViewModel, GZIPConverterPage>();
            Configure<GZIPConverterDetailViewModel, GZIPConverterDetailPage>();
            Configure<JWTDecoderViewModel, JWTDecoderPage>();
            Configure<JWTDecoderDetailViewModel, JWTDecoderDetailPage>();
            Configure<TextDiffViewModel, TextDiffPage>();
            Configure<TextDiffDetailViewModel, TextDiffDetailPage>();
            Configure<RegexTesterViewModel, RegexTesterPage>();
            Configure<RegexTesterDetailViewModel, RegexTesterDetailPage>();
            Configure<HashGeneratorViewModel, HashGeneratorPage>();
            Configure<HashGeneratorDetailViewModel, HashGeneratorDetailPage>();
        }

        public Type GetPageType(string key)
        {
            Type pageType;
            lock (_pages)
            {
                if (!_pages.TryGetValue(key, out pageType))
                {
                    throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
                }
            }

            return pageType;
        }

        private void Configure<VM, V>()
            where VM : ObservableObject
            where V : Page
        {
            lock (_pages)
            {
                var key = typeof(VM).FullName;
                if (_pages.ContainsKey(key))
                {
                    throw new ArgumentException($"The key {key} is already configured in PageService");
                }

                var type = typeof(V);
                if (_pages.Any(p => p.Value == type))
                {
                    throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
                }

                _pages.Add(key, type);
            }
        }
    }
}
