namespace YMK.FrameWork.Commons.Contexts
{
    public class AppServiceContext : BaseCommonContext
    {
        static AppServiceContext _context;

        public static AppServiceContext Context
        {
            get
            {
                if (_context == null)
                    _context = new AppServiceContext();
                return _context;
            }
        }

    }
}
