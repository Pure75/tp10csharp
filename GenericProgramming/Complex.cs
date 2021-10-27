using System;
using System.Diagnostics;

namespace WWW
{
    public class Complex
    {
        public float real;
        public float img;

        /// <summary>
        /// Assigns the real and imaginary part of the complexe
        /// </summary>
        /// <param name="real"> Real part</param>
        /// <param name="filter"> Imaginary Part</param>
        public Complex(float real, float img)
        {
            this.real = real;
            this.img = img;
        }
        
        /// <summary>
        /// Returns a string representing the complex
        /// </summary>
        public override string ToString()
        {
            string res = "";
            if (img >= 0) res = real + "+i" + img;
            else res = real + "-i" + Math.Abs(img);
            return res;
        }
        
        /// <summary>
        /// Returns the addition between lhs and rhs
        /// </summary>
        /// <param name="lhs"> Complex on the left of the '+' symbol</param>
        /// <param name="rhs"> Complex on the right of the '+' symbol</param>
        public static Complex operator +(Complex lhs, Complex rhs)
        {
            Complex res = new Complex(lhs.real + rhs.real, rhs.img + lhs.img);
            return res;
        }
        
        /// <summary>
        /// Returns the subtraction between lhs and rhs
        /// </summary>
        /// <param name="lhs"> Complex on the left of the '-' symbol</param>
        /// <param name="rhs"> Complex on the right of the '-' symbol</param>
        public static Complex operator -(Complex lhs, Complex rhs)
        {
            Complex res = new Complex(lhs.real - rhs.real, lhs.img - rhs.img);
            return res;
        }
        
        /// <summary>
        /// Returns the multiplication between lhs and rhs
        /// </summary>
        /// <param name="lhs"> Complex on the left of the '*' symbol</param>
        /// <param name="rhs"> Complex on the right of the '*' symbol</param>
        public static Complex operator *(Complex lhs, Complex rhs)
        {
            Complex res =
                    new Complex(lhs.real * rhs.real - lhs.img * rhs.img, lhs.img * rhs.real + lhs.real * rhs.img);
            return res;
        }

        /// <summary>
        /// Returns the division between lhs and rhs
        /// </summary>
        /// <param name="lhs"> Complex on the left of the '/' symbol</param>
        /// <param name="rhs"> Complex on the right of the '/' symbol</param>
        public static Complex operator /(Complex lhs, Complex rhs)
        {
            if (rhs.real == 0 || rhs.img == 0) throw new DivideByZeroException();
            else
            {
                float diviseur = (rhs.real * rhs.real + rhs.img * rhs.img);

                Complex dividende =
                    new Complex(lhs.real * rhs.real + lhs.img * rhs.img, lhs.img * rhs.real + lhs.real * -rhs.img);
                Complex res = new Complex(dividende.real / diviseur, dividende.img / diviseur);
                return res;
            }
        }

        /// <summary>
        /// Returns true if lhs is equal to rhs
        /// </summary>
        /// <param name="lhs"> Complex on the left of the '==' symbol</param>
        /// <param name="rhs"> Complex on the right of the '==' symbol</param>
        public static bool operator ==(Complex lhs, Complex rhs)
        {
            return (lhs.real == rhs.real && lhs.img == rhs.img);
        }

        /// <summary>
        /// Returns true if lhs is not equal to rhs
        /// </summary>
        /// <param name="lhs"> Complex on the left of the '==' symbol</param>
        /// <param name="rhs"> Complex on the right of the '==' symbol</param>
        public static bool operator !=(Complex lhs, Complex rhs)
        {
            return (lhs.real != rhs.real || lhs.img != rhs.img);
        }
    }
}