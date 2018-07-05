using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ECommerce.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {   
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UOM> UOMs { get; set; }
        public DbSet<ParentCategory> ParentCategorys { get; set; }
        public DbSet<ChildCategory> ChildCategorys { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CartLineItem> CartLineItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<UserBasket> UserBaskets { get; set; }
    }
}