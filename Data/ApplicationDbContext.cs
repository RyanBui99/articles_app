using articles_app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace articles_app.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BlogPostModel> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // any unique string id
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ADMIN_ROLE_ID = "ad376a8f-9eab-4bb9-9fca-30b01540f445";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "admin",
                NormalizedName = "ADMIN",
            });

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                PasswordHash = hasher.HashPassword(null, "Admin123#"),
                EmailConfirmed = true,
                NormalizedUserName = "ADMIN@ADMIN.COM",
                NormalizedEmail = "ADMIN@ADMIN.COM"
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });

            builder.Entity<BlogPostModel>().HasData(new BlogPostModel
            {
                Id = Guid.NewGuid().ToString(),
                Header = "Lorem ipsum",
                Content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam convallis volutpat sem, eu porttitor sem ornare sed. Praesent efficitur luctus felis eu molestie. Aenean eget leo euismod, volutpat erat non, viverra sapien. Pellentesque venenatis libero egestas ullamcorper laoreet. Vivamus gravida eu elit maximus egestas. In dictum vitae dolor ac volutpat. Nunc sagittis ipsum orci, eget fringilla velit lacinia eget. Nulla facilisi. Duis ex purus, interdum id orci sed, scelerisque blandit turpis.

                        Quisque vel nibh tincidunt, porta eros in, vestibulum mauris. Proin pretium est justo, vitae molestie ante porta sed. Praesent posuere elit turpis, non luctus nulla tristique vitae. Suspendisse et orci fringilla, pellentesque eros dapibus, sagittis leo. Ut ut massa ac metus sagittis consequat ut sit amet eros. Maecenas sit amet imperdiet risus. Vivamus sed bibendum est. In auctor ut est pulvinar mattis. Donec iaculis finibus sem, vitae sodales tortor fermentum et. Nunc vestibulum accumsan mi dictum facilisis. Pellentesque iaculis risus id mollis mattis. Aliquam aliquet, sapien iaculis bibendum congue, mi ante consequat erat, eget dictum arcu erat eu enim.

                        Cras euismod ante sit amet leo ultricies condimentum. Proin pharetra eleifend erat, at iaculis libero posuere vel. Morbi sed egestas sem, ac vulputate lectus. Nam iaculis pharetra sem a pellentesque. Donec a massa dolor. Vivamus venenatis nunc non sem rhoncus interdum. Suspendisse varius vulputate pulvinar. Sed facilisis dignissim iaculis. Mauris bibendum nisi sem, eu malesuada ipsum posuere ut. Nulla vel mi dictum, imperdiet nunc at, feugiat mauris. Aliquam venenatis laoreet lectus, et hendrerit enim mattis non. Praesent elementum facilisis arcu quis lacinia.

                        Praesent vitae ullamcorper elit, sit amet tincidunt mauris. Aliquam erat volutpat. Ut congue libero nisi, eleifend ultricies lorem efficitur non. Phasellus ut vehicula nisi. Etiam mattis eleifend nibh et malesuada. Praesent a ligula posuere, consectetur leo in, sodales urna. Sed non sapien tempor, efficitur erat eget, viverra dolor. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer tempor iaculis pulvinar. In pulvinar bibendum neque ac vulputate. Sed eu ultricies erat, et lobortis nisi. Aenean consectetur, ex a pharetra imperdiet, quam erat sagittis sem, ac condimentum nisi erat sit amet velit. Proin viverra eget ex sed efficitur. Nunc eget placerat ligula.

                        Aenean vel dolor ultricies sapien ornare imperdiet nec eu neque. Mauris ligula justo, congue rutrum orci ac, tristique imperdiet justo. Vivamus pellentesque pretium elit, ac imperdiet augue imperdiet nec. Donec a libero vehicula, finibus ante nec, accumsan velit. Nullam quis efficitur lacus, nec auctor tortor. Ut sollicitudin elit et dolor tincidunt pulvinar. Praesent ut nunc vitae nisi tristique hendrerit. Maecenas lectus nisl, fringilla in porta sit amet, pharetra in quam. Maecenas pharetra, nunc eu feugiat pretium, purus dui blandit purus, sit amet placerat massa metus eget enim. Donec auctor quis nulla et rhoncus. Donec congue aliquam arcu, ut euismod tortor hendrerit sollicitudin. In sit amet massa quis purus luctus commodo. Suspendisse dapibus felis tortor. Donec luctus tellus at feugiat posuere. Nunc tempor orci a mi pharetra tristique.

                        Quisque ac facilisis ante, in ornare est. Sed mattis nunc nunc, at dictum lorem pharetra suscipit. Nulla suscipit magna elit, non scelerisque ex porttitor vel. Vestibulum quis finibus velit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse et luctus orci, id semper diam. Nullam faucibus eros augue, eu efficitur libero molestie quis. Pellentesque malesuada felis et quam gravida, vitae tincidunt nibh ornare. Cras ut vulputate eros.

                        Phasellus pretium in massa quis mollis. Etiam semper sed tortor at vestibulum. Praesent dignissim iaculis mauris, ut vehicula sapien fermentum eu. Aenean fermentum eu est at placerat. Maecenas placerat ut urna ut maximus. Aenean sit amet ipsum lectus. Nam id ligula non orci egestas efficitur.

                        Integer vitae finibus magna. Nulla non consectetur tortor. Vivamus venenatis arcu tellus, ac volutpat odio congue sit amet. Mauris eu quam dui. Ut eu aliquet nibh. Donec venenatis mi non mauris lobortis, in tristique nulla finibus. Praesent accumsan, dolor vestibulum vulputate consequat, metus odio euismod turpis, eu posuere ligula risus at felis. Donec laoreet dapibus odio, nec lobortis tortor elementum eget. Sed venenatis justo a ex sollicitudin ultrices. Vivamus ultricies vestibulum elit, eu egestas lectus.

                        Phasellus tincidunt sem ut justo consequat, non lacinia felis eleifend. Cras consequat finibus laoreet. Sed sapien ex, elementum eget volutpat sit amet, tempus vulputate lorem. Proin interdum purus sit amet imperdiet cursus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nunc lobortis nulla commodo, bibendum lorem et, imperdiet elit. In maximus et lorem nec dignissim. Praesent ultrices dui non ex pharetra mattis. Etiam vulputate lorem purus. Donec et nibh at ex malesuada auctor. Cras a nulla feugiat, porttitor nunc sed, iaculis justo. Etiam et turpis vel nisl placerat rhoncus non tempor augue.

                        Interdum et malesuada fames ac ante ipsum primis in faucibus. Fusce in felis in est facilisis dapibus. Mauris rutrum sapien at vehicula dictum. Quisque faucibus nunc sed commodo efficitur. Nunc congue commodo imperdiet. Ut laoreet justo dui, vitae dignissim libero sodales ac. Proin ut tellus laoreet, cursus velit eu, fringilla ex. Etiam rhoncus massa nec imperdiet gravida. Vivamus venenatis tempus erat vel egestas.

                        Aliquam erat volutpat. Proin sit amet ullamcorper nunc, eu sagittis mi. Sed pretium, leo in iaculis finibus, libero augue elementum risus, id luctus nunc diam at massa. Proin vel nunc porttitor, elementum quam eu, luctus erat. Morbi placerat sodales nisl eget egestas. Morbi in hendrerit enim, sed mollis sem. Vestibulum justo diam, aliquet eu maximus eget, scelerisque ut tellus. Fusce bibendum odio convallis, convallis nisi id, euismod nunc. Nam vitae rhoncus nunc. Lorem ipsum dolor sit amet, consectetur adipiscing elit.

                        Suspendisse potenti. Donec a imperdiet justo. Maecenas nec luctus tellus. Integer ultrices rutrum magna, ut interdum massa congue at. Mauris vel ante dignissim urna venenatis imperdiet at eu mi. In rhoncus, nunc eget euismod maximus, diam lacus euismod justo, nec mollis felis tellus eget eros. Duis eu nunc dignissim felis varius tincidunt vehicula in eros. Cras ut ex a augue dapibus fermentum. Pellentesque porttitor gravida ipsum, volutpat imperdiet orci mollis eu. Vestibulum feugiat ante non mauris dapibus, eget ultricies nibh facilisis. Quisque pulvinar, risus id feugiat iaculis, magna libero mattis nunc, vel accumsan diam enim in velit. Phasellus dignissim nisl ut nibh sollicitudin pellentesque. Vivamus eget lorem efficitur, semper felis a, efficitur velit. Donec imperdiet enim quis dignissim elementum.

                        Suspendisse blandit enim justo, et pharetra augue mattis ac. Fusce ultricies dui metus, a faucibus sapien aliquet a. Nullam vulputate justo erat, quis blandit mauris placerat sit amet. Donec tempus enim arcu, sit amet tempor enim pellentesque non. Aliquam interdum metus vitae dolor maximus, ut laoreet ipsum hendrerit. Nam semper commodo ex, vel vestibulum arcu volutpat a. Aenean mollis placerat lacus, volutpat tempor eros dignissim vel. Nunc rutrum augue nisl, blandit commodo ligula gravida id. Sed rhoncus est sed erat pellentesque, id egestas lacus imperdiet. Nulla et bibendum augue. Integer et mattis diam. Quisque in dui sed elit varius suscipit et nec orci. Aenean non vehicula libero. Praesent aliquet sit amet turpis ac pretium.

                        Integer bibendum diam nulla, sed volutpat eros ornare quis. Donec nec eleifend dui. Nullam suscipit ligula nec faucibus molestie. Nam quam tortor, hendrerit nec sollicitudin tincidunt, interdum sit amet elit. Donec ut odio tristique, sodales mauris ut, dictum velit. Nunc sed eros et risus iaculis sollicitudin. Phasellus lacinia dignissim lobortis. Duis tempus ligula at lorem pulvinar, at interdum massa condimentum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Suspendisse iaculis arcu et rhoncus facilisis. Praesent blandit ligula arcu, ut molestie urna feugiat faucibus. Mauris tristique, ligula eu tristique posuere, dui justo dictum sapien, nec egestas nisl sem et sapien.

                        In posuere accumsan mi in euismod. Vivamus blandit metus sit amet metus tincidunt mollis. Donec tempor orci sed placerat semper. Nulla dapibus finibus est ut gravida. Morbi sodales eros pulvinar urna fermentum, non consequat neque luctus. Suspendisse eget blandit nisi. Sed vehicula pharetra eros nec tempor. Maecenas consectetur neque vel magna dapibus, et euismod diam egestas. Pellentesque ut risus metus. Suspendisse ligula libero, egestas a vehicula in, dignissim in dolor. Nam in nibh in risus commodo egestas. Duis lacinia velit quis dui tincidunt, a dapibus ipsum venenatis. Nullam id tortor ac dolor aliquam consequat. In sodales, felis vitae convallis placerat, dui diam blandit ligula, non feugiat turpis dolor id dolor. Phasellus non purus libero.

                        Phasellus tincidunt in erat sed dignissim. Duis vehicula dolor nunc, vel finibus ante iaculis id. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum laoreet quis diam sed rutrum. Curabitur elementum faucibus magna, quis lobortis diam porttitor at. Cras pharetra consectetur tortor ut eleifend. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris finibus volutpat gravida. Nunc bibendum massa nulla, in malesuada massa ultrices ut. Vivamus pharetra dapibus elit, id malesuada libero porta sit amet. Proin quis metus non turpis dapibus vehicula eget a metus.

                        Vestibulum eget dapibus urna, ut ornare ante. Vestibulum quis diam vitae justo posuere consectetur a id leo. Aenean sit amet enim felis. Nulla vehicula consequat diam non suscipit. Pellentesque blandit congue ligula, non suscipit lectus ullamcorper et. Suspendisse eleifend feugiat augue, at vulputate mi dictum hendrerit. Maecenas in ipsum viverra, fringilla est eget, dapibus augue. Nullam pretium urna blandit quam porttitor auctor. Phasellus luctus commodo dignissim. Ut aliquet efficitur ante, sit amet tempor massa feugiat varius. Nam semper pharetra augue, in vestibulum justo tincidunt quis. Duis risus metus, ornare quis vestibulum sit amet, volutpat ac dui. Vestibulum non purus ac mauris maximus condimentum.

                        Donec fringilla libero aliquam nisi imperdiet, vitae fringilla orci pellentesque. Suspendisse ut est ac eros luctus ornare. Integer diam libero, rutrum vitae nisl id, fermentum vehicula lacus. Ut a arcu sit amet nulla elementum condimentum at maximus sem. Vivamus rutrum eleifend eros, quis luctus massa interdum eget. Ut viverra dolor vitae dolor pulvinar, eget lacinia arcu tempor. Quisque sit amet massa feugiat, porttitor lectus sit amet, varius orci. Nam vitae elit libero. Sed iaculis, nulla ac sagittis tincidunt, ligula erat ornare sapien, quis mollis lectus mi ut elit. Quisque gravida, ipsum nec elementum tempus, dolor ipsum egestas arcu, at auctor lectus nisi id magna.

                        Nam a condimentum lacus, id tempus ligula. Nulla luctus ultrices aliquet. Donec non metus sed libero ultrices faucibus. Aliquam imperdiet eros et ultricies malesuada. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Integer consequat purus id arcu pellentesque dictum. Phasellus aliquam risus sapien, quis accumsan ipsum eleifend sit amet. Etiam interdum massa porttitor ante bibendum accumsan.

                        Vestibulum mollis sem libero, eget maximus justo sagittis id. Duis consectetur augue ullamcorper nunc luctus, nec fermentum dolor mattis. Nam a pellentesque ex. Nunc nec lacus a nisi fermentum tristique. Vestibulum scelerisque arcu a pulvinar tincidunt. Donec id rhoncus sapien. Ut in rutrum justo, nec posuere ante. Maecenas viverra tortor in quam eleifend, at sollicitudin justo commodo. Donec sit amet sollicitudin ex. Etiam et magna euismod, maximus sem non, facilisis ipsum. Mauris pulvinar maximus tempor. Integer posuere lobortis metus ut consectetur.
                        ",
                ImageUrl = "sad"

            }
        }
    }
}
