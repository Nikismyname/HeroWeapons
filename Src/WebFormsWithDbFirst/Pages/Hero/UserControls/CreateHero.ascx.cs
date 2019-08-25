using System;
using System.Linq;
using System.Web.UI;
using WebFormsWithDbFirst.HeroModelDesigner;
using WebFormsWithDbFirst.Pages.Hero;

namespace WebFormsWithDbFirst.Pages.UserComponents
{
    public partial class CreateHero : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateHero_Click(object sender, EventArgs e)
        {
            var name = TBHeroName.Text;
            if (name.Length == 0 || name.All(x => x == ' '))
            {
                //msgLabel.Text = "Invalid Hero Name!";
                return;
            }

            using (var context = new HeroDbConnStr())
            {
                var newHero = new WebFormsWithDbFirst.HeroModelDesigner.Hero()
                {
                    Name = name
                };

                context.Hero.Add(newHero);
                context.SaveChanges();
            }

            HeroPage heroPage = (HeroPage)this.Page;
            heroPage.BindAllHeroNames(); 

            //UpdatePanel heroUpdatePanel = (UpdatePanel)this.Parent.FindControl("HeroUpdatePanel");
            //heroUpdatePanel.Update();
        }
    }
}