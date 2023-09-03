using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sample_Library_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        char[] turkish_characters = new char[] { 'Ç', 'İ', 'Ğ', 'Ş', 'Ö', 'Ü' };
        char[] english_characters = new char[] { 'C', 'I', 'G', 'S', 'O', 'U' };
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Dosya Adı Boş Olamaz !");
                return;
            }
            folderBrowserDialog1.Description = "Taslak Dosyaların Kaydedileceği Klasörü Seçiniz";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sample_header_file_create(folderBrowserDialog1.SelectedPath);
                sample_source_file_create(folderBrowserDialog1.SelectedPath);
            }
            else
            {
                MessageBox.Show("Dosya Kayıt Klasörü Seçilmedi !");
            }
        }
        private void sample_header_file_create(string path)
        {
            string file_name = "makel_" + textBox1.Text + ".h";
            string full_path = path + "\\" + file_name;
            string upper_file_name = textBox1.Text.ToUpper();

            for (int i = 0; i < turkish_characters.Length; i++)
            {
                upper_file_name = upper_file_name.Replace(turkish_characters[i], english_characters[i]);
            }

            if (File.Exists(full_path))
            {
                System.IO.File.Delete(full_path);
            }
            FileStream fs = new FileStream(full_path, FileMode.Create, FileAccess.Write);
            fs.Close();
            File.AppendAllText(full_path, "/**" + Environment.NewLine);
            File.AppendAllText(full_path, "*****************************************************************************" + Environment.NewLine);
            File.AppendAllText(full_path, " * @file          : " + file_name + Environment.NewLine);
            File.AppendAllText(full_path, " * @brief         : Header for makel_" + textBox1.Text + ".c file." + Environment.NewLine);
            File.AppendAllText(full_path, " *                  This file contains the common defines of the application." + Environment.NewLine);
            File.AppendAllText(full_path, "*****************************************************************************" + Environment.NewLine);
            File.AppendAllText(full_path, " * @attention" + Environment.NewLine);
            File.AppendAllText(full_path, " *" + Environment.NewLine);
            File.AppendAllText(full_path, " * - Fonksiyon isimlendirmeleri modül adıyla başlamalı ve devamında gelecek" + Environment.NewLine);
            File.AppendAllText(full_path, " *   olan kelimeler _ ile ayrılmalıdır." + Environment.NewLine);
            File.AppendAllText(full_path, " * - Fonksiyonlar yapacağı işe açıkça anlatacak şekilde isimlendirilmelidir." + Environment.NewLine);
            File.AppendAllText(full_path, " * - Fonksiyon isimlendirmeleri küçük harfler kullanılacak yapılmalıdır." + Environment.NewLine);
            File.AppendAllText(full_path, " * - Public fonksiyon prototipleri ilgili modülün header dosyasında" + Environment.NewLine);
            File.AppendAllText(full_path, " *   tanımlanmalıdır." + Environment.NewLine);
            File.AppendAllText(full_path, " * - Sadece modül içerisinde kullanılacak fonksiyonlar static olarak" +  Environment.NewLine);
            File.AppendAllText(full_path, " *   modulün source dosyasında tanımlanmalıdır." + Environment.NewLine);
            File.AppendAllText(full_path, " * - Örnek Fonksiyon İsimlendirmeleri : " + Environment.NewLine);
            File.AppendAllText(full_path, " * - makel_" + textBox1.Text + "_init();" + Environment.NewLine);
            File.AppendAllText(full_path, " * - makel_" + textBox1.Text + "_deinit();" + Environment.NewLine);
            File.AppendAllText(full_path, " *" + Environment.NewLine);

            File.AppendAllText(full_path, " * - Yazılan bütün fonksiyonlara açıklama eklenmelidir." + Environment.NewLine);
            File.AppendAllText(full_path, " * - Eğer fonksiyon içerisinde kullanılan özel bir formül ya da" + Environment.NewLine);
            File.AppendAllText(full_path, " *   özel bir işlem varsa, bu işlem fonksiyon içerisinde açıklanmalıdır." + Environment.NewLine);
            File.AppendAllText(full_path, " * - Mümkün olan bütün fonksiyonlar yapılan işlemin başarılı ya da " + Environment.NewLine);
            File.AppendAllText(full_path, " *   başarısız olduğunu return ile döndürmelidir." + Environment.NewLine);
            File.AppendAllText(full_path, " * - Örnek Fonksiyon : " + Environment.NewLine);
            File.AppendAllText(full_path, "/**" + Environment.NewLine);
            File.AppendAllText(full_path, " * @brief         : makel_" + textBox1.Text + "_led_on" + Environment.NewLine);
            File.AppendAllText(full_path, " * Bu fonksiyon istenilen led'in durumunu on'a çeker." + Environment.NewLine);
            File.AppendAllText(full_path, " * @param led_num on yapılması istenilen led" + Environment.NewLine);
            File.AppendAllText(full_path, " * @return int işlem başarılı ise 0, başarısız ise -1 döner" + Environment.NewLine);
            File.AppendAllText(full_path, " */" + Environment.NewLine);
            File.AppendAllText(full_path, "/*" + Environment.NewLine);
            File.AppendAllText(full_path, " int makel_" + textBox1.Text + "_led_on(uint8_t led_num)" + Environment.NewLine);
            File.AppendAllText(full_path, " {" + Environment.NewLine);
            File.AppendAllText(full_path, "  ." + Environment.NewLine);
            File.AppendAllText(full_path, "  ." + Environment.NewLine);
            File.AppendAllText(full_path, "  if(error)" + Environment.NewLine);
            File.AppendAllText(full_path, "  {" + Environment.NewLine);
            File.AppendAllText(full_path, "    return -1" + Environment.NewLine);
            File.AppendAllText(full_path, "  }" + Environment.NewLine);
            File.AppendAllText(full_path, "  return 0" + Environment.NewLine);
            File.AppendAllText(full_path, "  ." + Environment.NewLine);
            File.AppendAllText(full_path, "  ." + Environment.NewLine);
            File.AppendAllText(full_path, " }" + Environment.NewLine);
            File.AppendAllText(full_path, "*/" + Environment.NewLine);
            File.AppendAllText(full_path, "/*" + Environment.NewLine);
            File.AppendAllText(full_path, "* Daha fazla kod yazım kuralı için" + Environment.NewLine);
            File.AppendAllText(full_path, "* https://barrgroup.com/sites/default/files/barr_c_coding_standard_2018.pdf" + Environment.NewLine);
            File.AppendAllText(full_path, "* dökümanını inceleyebilirsiniz." + Environment.NewLine);
            File.AppendAllText(full_path, "*/" + Environment.NewLine);


            File.AppendAllText(full_path, "#ifndef __MAKEL_" + upper_file_name + "_H__" + Environment.NewLine);
            File.AppendAllText(full_path, "#define __MAKEL_" + upper_file_name + "_H__" + Environment.NewLine);
            File.AppendAllText(full_path, Environment.NewLine);

            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                         Public Include Section                         **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);

            File.AppendAllText(full_path, Environment.NewLine);

            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                         Public Define Section                          **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);

            File.AppendAllText(full_path, Environment.NewLine);

            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                    Public Structure and Enum Section                   **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);

            File.AppendAllText(full_path, Environment.NewLine);

            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                    Public Function Prototype Section                   **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);

            File.AppendAllText(full_path, Environment.NewLine);
            File.AppendAllText(full_path, "#endif /* __MAKEL_" + upper_file_name + "_H__ */");

        }
        private void sample_source_file_create(string path)
        {
            string file_name = "makel_" + textBox1.Text + ".c";
            string full_path = path + "\\" + file_name;

            if (File.Exists(full_path))
            {
                System.IO.File.Delete(full_path);
            }
            FileStream fs = new FileStream(full_path, FileMode.Create, FileAccess.Write);
            fs.Close();

            File.AppendAllText(full_path, "/**" + Environment.NewLine);
            File.AppendAllText(full_path, "*****************************************************************************" + Environment.NewLine);
            File.AppendAllText(full_path, " * @file          : makel_" + textBox1.Text + ".c" + Environment.NewLine);
            File.AppendAllText(full_path, " * @brief         : Application module for makel_" + textBox1.Text + ".c" + Environment.NewLine);
            File.AppendAllText(full_path, "*****************************************************************************" + Environment.NewLine);
            File.AppendAllText(full_path, "*/" + Environment.NewLine);

            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                          Private Include Section                       **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);
            File.AppendAllText(full_path, "#include \"makel_" + textBox1.Text + ".h\"" + Environment.NewLine);

            File.AppendAllText(full_path, Environment.NewLine);

            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                         Private Define Section                         **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);

            File.AppendAllText(full_path, Environment.NewLine);

            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                    Private Structure and Enum Section                  **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);

            File.AppendAllText(full_path, Environment.NewLine);

            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                           Variables Section                            **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);

            File.AppendAllText(full_path, Environment.NewLine);

            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                    Private Function Prototype Section                  **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);

            File.AppendAllText(full_path, Environment.NewLine);

            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                           Private Functions                            **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);

            File.AppendAllText(full_path, Environment.NewLine);

            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                            Public Functions                            **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/**                                                                        **/" + Environment.NewLine);
            File.AppendAllText(full_path, "/****************************************************************************/" + Environment.NewLine);

            File.AppendAllText(full_path, Environment.NewLine);


        }
    }
}
