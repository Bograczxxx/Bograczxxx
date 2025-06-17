using Grpc.Core;
using BograczApi.Data;
using BograczApi.Models;

namespace BograczApi.Services
{
    public class ProductGrpcService : ProductService.ProductServiceBase
    {
        private readonly AppDbContext _db;
        public ProductGrpcService(AppDbContext db)
        {
            _db = db;
        }

        public override Task<ProductReply> AddProduct(ProductRequest request, ServerCallContext context)
        {
            var product = new Product { Name = request.Name, Price = (decimal)request.Price };
            _db.Products.Add(product);
            _db.SaveChanges();
            return Task.FromResult(new ProductReply { Id = product.Id, Name = product.Name, Price = (double)product.Price });
        }

        public override Task<ProductReply> GetProduct(ProductLookup request, ServerCallContext context)
        {
            var product = _db.Products.Find(request.Id);
            if (product == null) throw new RpcException(new Status(StatusCode.NotFound, "Not found"));
            return Task.FromResult(new ProductReply { Id = product.Id, Name = product.Name, Price = (double)product.Price });
        }

        public override Task<Empty> DeleteProduct(ProductLookup request, ServerCallContext context)
        {
            var product = _db.Products.Find(request.Id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            return Task.FromResult(new Empty());
        }
    }
}
