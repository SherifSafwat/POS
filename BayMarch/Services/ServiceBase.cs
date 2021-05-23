using BayMarch.Data;

namespace BayMarch.Services
{
    public class ServiceBase
    {
        public readonly string userId_tmp;
        public readonly DataContext _context_tmp;
        /*private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _us;
        private readonly JwtBearerHandler _jt;
        private readonly IHttpContextAccessor _ht;*/
        //private readonly ILogger _lo;

        public ServiceBase()
        {
            //int i= 0;
        }
        public ServiceBase(DataContext context)
        //public ServiceBase(DataContext context, IMapper mapper, UserManager<ApplicationUser> userManager
            //, IUserStore<ApplicationUser> us, JwtBearerHandler jt, IHttpContextAccessor ht)
        {
            //_context = context;

            //userId = "user";
            
            /*_mapper = mapper;

            _userManager = userManager;
            _us = us;
            _jt = jt;
            _ht = ht;
            // _lo=  lo;


            ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.UserName == ht.HttpContext.User.Identity.Name);

            var t = context.Users.FirstOrDefault(x => x.UserName == ht.HttpContext.User.Identity.Name).Id;*/

        }

    }
}