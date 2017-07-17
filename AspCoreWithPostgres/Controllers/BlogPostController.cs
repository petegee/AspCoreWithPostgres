using Marten;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreWithPostgres.Controllers
{
    [Route("/posts")]
    public class BlogPostController
    {
        private readonly IDocumentStore documentStore;

        public BlogPostController(IDocumentStore documentStore)
        {
            this.documentStore = documentStore;
        }

        [HttpGet]
        public IEnumerable<BlogPost> Get()
        {
            using (var session = documentStore.QuerySession())
            {
                return session.Query<BlogPost>();
            }
        }

        [HttpGet("{id}")]
        public BlogPost Get(int id)
        {
            using (var session = documentStore.QuerySession())
            {
                return session
                    .Query<BlogPost>()
                    .Where(post => post.Id == id)
                    .FirstOrDefault();

            }
        }

        [HttpPost]
        public BlogPost Create([FromBody]BlogPost post)
        {
            using (var session = documentStore.LightweightSession())
            {
                session.Store(post);
                session.SaveChanges();
                return post;
            }
        }
    }
}
