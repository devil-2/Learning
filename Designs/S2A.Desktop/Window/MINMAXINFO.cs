using System.Runtime.InteropServices;

namespace S2A.Desktop
{
    #region DLL Helper Structures

    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {
#pragma warning disable IDE1006 // Naming Styles
        public POINT PointReserved;
        public POINT PointMaxSize;
        public POINT PointMaxPosition;
        public POINT PointMinTrackSize;
        public POINT PointMaxTrackSize;
#pragma warning restore IDE1006 // Naming Styles
    };

    #endregion
}
