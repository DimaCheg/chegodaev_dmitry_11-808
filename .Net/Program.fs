#light
open System
open System.Numerics
open System.Drawing
open System.Windows.Forms

let mandelf (c:Complex) (z:Complex) = z*z+c

let rec rpt n f =
    if n = 0 then
        (fun x -> x)
    else
        f >> (rpt (n-1) f)

// из вики: ...вычисляется значение модуля
// ...сравнивается с «границей бесконечности» (обычно берётся значение, равное 2)
let ismandel c = Complex.Abs(rpt 20 (mandelf c) (Complex.Zero)) < 2.0
let scale (x:float, y:float) (u, v) n = float(n-u) / float(v-u)*(y-x)+x

let form =

   let image = new Bitmap(400, 400)

   let lscale = scale (-1.2,1.2) (0,image.Height-1)

   for i = 0 to (image.Height-1) do

     for j = 0 to (image.Width-1) do

       let t = new Complex((lscale i), (lscale j)) in

       image.SetPixel(i,j,if ismandel t then Color.Black else Color.White)

   let temp = new Form()

   temp.Paint.Add(fun e -> e.Graphics.DrawImage(image, 0, 0))

   temp

do Application.Run(form)