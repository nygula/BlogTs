using System.Collections.Generic;
using TsBlog.Domain.Entities;
using TsBlog.Repositories;

namespace TsBlog.Services
{
    public class PostService : GenericService<Post>, IPostService
    {
        private readonly IPostRepository _repository;
        public PostService(IPostRepository repository) : base(repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 查询首页文章列表
        /// </summary>
        /// <param name="limit">要查询的记录数</param>
        /// <returns></returns>
        public IEnumerable<Post> FindHomePagePosts(int limit = 20)
        {
            return _repository.FindHomePagePosts(limit);
        }

        public bool Delete(Post entity)
        {
            return _repository.Delete(entity);
        }

        public bool DeleteById(object id)
        {
            return _repository.DeleteById(id);
        }

        public bool DeleteByIds(object[] ids)
        {
            return _repository.DeleteByIds(ids);
        }

        public IEnumerable<Post> FindAll()
        {
            return _repository.FindAll();
        }

        public Post FindById(int id)
        {
            return _repository.FindById(id);
        }

        public long Insert(Post entity)
        {
            return _repository.Insert(entity);
        }

        public bool Update(Post entity)
        {
            return _repository.Update(entity);
        }
    }
}
