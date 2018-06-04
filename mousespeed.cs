using System.Runtime.InteropServices;
public class WinAPI
{
    [DllImport("user32.dll", CharSet = CharSet.Auto),]
    public static extern int SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);
}