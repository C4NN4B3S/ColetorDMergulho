using System;

namespace Common.Helpers
{
    // Token: 0x02000024 RID: 36
    public static class ArrayUtils
    {
        // Token: 0x060000E2 RID: 226 RVA: 0x000053DC File Offset: 0x000035DC
        public static void Add<T>(ref T[] array, T newItem)
        {
            int num = array.Length + 1;
            Array.Resize<T>(ref array, num);
            array[num - 1] = newItem;
        }
    }
}
