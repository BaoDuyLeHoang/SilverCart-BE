﻿using Infrastructures.Interfaces.System;
using SkiaSharp;
using SkiaSharp.QrCode;
namespace Infrastructures.Services.System;

public class GenerateQRCodeGeneratorService : IGenerateQRCodeGeneratorService
{
    public byte[] GenerateQRCode(string url, int size = 256)
    {
        var qrCodeGenerator = new QRCodeGenerator();
        var qrCode = qrCodeGenerator.CreateQrCode(url, ECCLevel.Q);

        var info = new SKImageInfo(size, size);
        using var surface = SKSurface.Create(info);

        var area = new SKRect(0, 0, size, size);
        var canvas = surface.Canvas;

        canvas.Clear(SKColors.White);

        var qrCodeRenderer = new QRCodeRenderer();
        qrCodeRenderer.Render(canvas, area, qrCode, SKColors.Black, SKColors.White);

        canvas.Flush();

        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        return data.ToArray();
    }
    public string GenerateQRCodeBase64(string url, int size = 256)
    {
        var qrCodeGenerator = new QRCodeGenerator();
        var qrCode = qrCodeGenerator.CreateQrCode(url, ECCLevel.Q);

        var info = new SKImageInfo(size, size);
        using var surface = SKSurface.Create(info);
        var canvas = surface.Canvas;
        var area = new SKRect(0, 0, size, size);

        canvas.Clear(SKColors.White);

        var qrCodeRenderer = new QRCodeRenderer();
        qrCodeRenderer.Render(canvas, area, qrCode, SKColors.Black, SKColors.White);
        canvas.Flush();

        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        return Convert.ToBase64String(data.ToArray());
    }
}
