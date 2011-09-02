/*
 * Copyright (C) 2011 The Code Bakers
 * Authors: Cleuton Sampaio e Francisco Rodrigues
 * e-mail: thecodebakers@gmail.com
 * Project: http://code.google.com/p/criasenha-monodroid/
 * Site: http://thecodebakers.blogspot.com
 *
 * Licensed under the GNU LGPL, Version 3.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.gnu.org/licenses/lgpl.html
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 * @author Cleuton Sampaio e Francisco Rogrigues - thecodebakers@gmail.com
 */
using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using System.Text;

namespace CriaSenha
{
    [Activity(Label = "CriaSenha", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            EditText txtTam = FindViewById<EditText>(Resource.Id.TxtTamSenha);
            
            button.Click += delegate {
                int tamanho = int.Parse(txtTam.Text.ToString());
                string senha = calcSenha(tamanho);
                AlertDialog.Builder dialogo = new AlertDialog.Builder(this);
                dialogo.SetMessage(senha);
                dialogo.SetNeutralButton("Ok",
                        (o, e) => { Log.Debug("CriaSenha", "Clicou no OK"); });
                dialogo.Show();
            };
        }
        protected string calcSenha(int tamanho)
        {
            StringBuilder saida = new StringBuilder();
            int pos = 0;
            for (pos = 0; pos < tamanho; pos++)
            {
                int AsciiCode = 0;
                while(true) 
                {
                    Random random = new Random();
                    AsciiCode = Convert.ToChar(random.Next(48, 122));
                    if (AsciiCode < 58 ||
                        (AsciiCode > 64 && AsciiCode < 91) ||
                        (AsciiCode > 96 && AsciiCode < 123))
                    {
                        break;
                    }
                }
                Char letra = Convert.ToChar(AsciiCode);
                saida.Append(letra);
            }
            return saida.ToString();
        }
    }
}

