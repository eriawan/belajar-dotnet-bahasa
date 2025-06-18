using BenchmarkDotNet.Attributes;
using System.Runtime.Caching;

namespace DiskusiContohSkenarioValueTask
{
    [MemoryDiagnoser]
    public class SimpleWebContentReader
    {
        HttpClient httpClient = new HttpClient();
        string KompasComContent = string.Empty;
        MemoryCache memcache = MemoryCache.Default;
        const string WEBKOMPAS = "webkompas";

        public SimpleWebContentReader()
        {
            //memcache[WEBKOMPAS] = string.Empty;

        }

        [Params(50000, 100000, 200000)]
        public int NumberOfLoop;

        [Benchmark]
        public async Task GetWebContentBenchmarkTask()
        {
            for (int i = 0; i < NumberOfLoop; i++)
            {
                object webcontentObj = memcache.Get(WEBKOMPAS);
                string webcontent = string.Empty;
                if (webcontentObj is null)
                {
                    CacheItemPolicy cachewebKompas = new CacheItemPolicy();
                    cachewebKompas.SlidingExpiration = TimeSpan.FromHours(1);
                    webcontent = await httpClient.GetStringAsync("https://www.kompas.com");
                    memcache.Set(WEBKOMPAS, webcontent, cachewebKompas);
                }
                else
                {
                    webcontent = memcache.Get(key: WEBKOMPAS).ToString()!;
                } 
            }
        }

        [Benchmark]
        public async ValueTask GetWebContentBenchmarkValueTask()
        {
            for (int i = 0; i < NumberOfLoop; i++)
            {
                object webcontentObj = memcache.Get(WEBKOMPAS);
                string webcontent = string.Empty;
                if (webcontentObj is null)
                {
                    CacheItemPolicy cachewebKompas = new CacheItemPolicy();
                    cachewebKompas.SlidingExpiration = TimeSpan.FromHours(1);
                    webcontent = await httpClient.GetStringAsync("https://www.kompas.com");
                    memcache.Set(WEBKOMPAS, webcontent, cachewebKompas);
                }
                else
                {
                    webcontent = memcache.Get(key: WEBKOMPAS).ToString()!;
                } 
            }
        }

        internal async Task<string> GetWebContentUsingTask()
        {
            object webcontentObj = memcache.Get(WEBKOMPAS);
            string webcontent = string.Empty;
            if (webcontentObj is null)
            {
                CacheItemPolicy cachewebKompas = new CacheItemPolicy();
                cachewebKompas.SlidingExpiration = TimeSpan.FromSeconds(200);
                webcontent = await httpClient.GetStringAsync("https://www.kompas.com");
                memcache.Set(WEBKOMPAS, webcontent, cachewebKompas);
            } 
            else
            {
                webcontent = memcache.Get(key: WEBKOMPAS).ToString()!;
            }
            return webcontent;
        }
    }
}
