namespace YMK.FrameWork.Commons.Contexts
{
    public class InfrastructureContext : BaseCommonContext
    {
        static InfrastructureContext _context;

        public static InfrastructureContext Context
        {
            get
            {
                if (_context == null)
                    _context = new InfrastructureContext();
                return _context;
            }
        }
    }
}

