using CollectionManager.Models.entity;
using Elasticsearch.Net;
using Nest;
using System;

namespace CollectionManager.ElasticSearch
{
    public class ESConnection
    {
        private static String Index = "cm-index";
        private static String Type = "collection";
        private static String IndexTest = "cm-test-index";

        public static bool UnitTest = false;

        public static ElasticClient CollectionESClient()
        {
            return !UnitTest
                    ? EsClient() 
                        : EsClientTest();
        }

        private static ElasticClient EsClient()
        {
            var nodes = new Uri[]
            {
                new Uri("http://localhost:9200/"),
            };
            return new ElasticClient(new ConnectionSettings(
                                        new StaticConnectionPool(nodes)).
                                                MapDefaultTypeIndices(m => m
                                                    .Add(typeof(Collection), Index)).
                                                MapDefaultTypeNames(m => m
                                                    .Add(typeof(Collection), Type))
                                    );
        }



        private static ElasticClient EsClientTest()
        {
            var nodes = new Uri[]
            {
                new Uri("http://localhost:9200/"),
            };
            return new ElasticClient(new ConnectionSettings(
                                        new StaticConnectionPool(nodes)).
                                                MapDefaultTypeIndices(m => m
                                                    .Add(typeof(Collection), IndexTest)).
                                                MapDefaultTypeNames(m => m
                                                    .Add(typeof(Collection), Type))
                                    );
        }

    }
}