using System;

public static class GameEvents
{
    // Puan veren nesneler (elma) için olay
    // <int> yazmamýzýn sebebi, yakalanan her eþyanýn farklý bir puan deðeri taþýmasýdýr.
    public static Action<int> OnScoreItemCaught;

    // Bomba yakalandýðýnda tetiklenecek, veri taþýmasýna gerek olmayan "sade" bir olay
    public static Action OnBombCaught;
}
