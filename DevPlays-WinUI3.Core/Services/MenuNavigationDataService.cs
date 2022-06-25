using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevPlays_WinUI3.Core.Contracts.Services;
using DevPlays_WinUI3.Core.Models;

namespace DevPlays_WinUI3.Core.Services
{
    public class MenuNavigationDataService : IMenuNavigationDataService
    {
        private List<MenuNavigation> _allMenuNavigations;

        public MenuNavigationDataService()
        {
            
        }

        private static IEnumerable<MenuNavigation> AllMenu()
        {
            return new List<MenuNavigation>()
            {
                new MenuNavigation(){
                    Name = "Number Base Converter",
                    Description = "Convert numbers from one base to another",
                    NavigationName = "NumberBaseConverter",
                },
                new MenuNavigation(){
                    Name = "SQL Formatter",
                    Description = "Format SQL queries",
                    NavigationName = "SqlFormatter",
                },
                new MenuNavigation(){
                    Name = "XML Formatter",
                    Description = "Format XML",
                    NavigationName = "XmlFormatter",

                },
                new MenuNavigation(){
                    Name = "JSON Formatter",
                    Description = "Format JSON",
                    NavigationName = "JsonFormatter",
                },
                new MenuNavigation(){
                    Name = "Base 64 Encoder and Decoder",
                    Description = "Encode and decode base 64",
                    NavigationName = "Base64Converter",
                },
                new MenuNavigation()
                {
                    Name = "GZip Compressor and Decompressor",
                    Description = "Compress and decompress GZip",
                    NavigationName = "GZipConverter",
                },
                new MenuNavigation()
                {
                    Name = "JWT Decoder",
                    Description = "Decode JWT",
                    NavigationName = "JwtDecoder",
                },
                new MenuNavigation()
                {
                    Name = "Text Diff",
                    Description = "Compare two texts",
                    NavigationName = "TextDiff",
                },
                new MenuNavigation()
                {
                    Name = "Regex Tester",
                    Description = "Test regular expressions",
                    NavigationName = "RegexTester",
                },
                new MenuNavigation()
                {
                    Name = "Hash Generator",
                    Description = "Generate hashes",
                    NavigationName = "HashGenerator",
                },

            };
        }
        
        public async Task<IEnumerable<MenuNavigation>> GetContentGridDataAsync()
        {
            if (_allMenuNavigations == null)
            {
                _allMenuNavigations = new List<MenuNavigation>(AllMenu());
            }
            await Task.CompletedTask;
            return _allMenuNavigations;
        }
    }
}
