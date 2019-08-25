using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsWithDbFirst.HeroModelDesigner;
using WebFormsWithDbFirst.Pages.UserComponents;

namespace WebFormsWithDbFirst.Pages.Hero
{
    public partial class HeroPage : System.Web.UI.Page
    {
        private const string createHeroPath = "~/Pages/Hero/UserControls/CreateHero.ascx";
        private const string createWeaponPath = "~/Pages/Hero/UserControls/CreateWeapon.ascx";
        private const string HeroID = "SuperCustomHeroID";
        private const string WeaponID = "SuperCustomWeaponID"; 

        protected void Page_Load(object sender, EventArgs e)
        {
            var heroCreate = this.LoadControl(createHeroPath) as CreateHero;
            heroCreate.ID = HeroID; 
            PH1.Controls.Add(heroCreate);

            BindRepeater();
            BindAllHeroNames();
            BindAllWeaponNames();
        }

        public void BindRepeater()
        {
            using (var context = new HeroDbConnStr())
            {
                var data = context.udf_favourite_weapon();
                TableRepeater.DataSource = data;
                TableRepeater.DataBind(); 
            }
        }

        public void BindAllHeroNames()
        {
            using (var context = new HeroDbConnStr())
            {
                var data = context.Hero.ToArray();
                HeroNameRepeater.DataSource = data;
                HeroNameRepeater.DataBind();
            }
        }

        public void BindAllWeaponNames()
        {
            using (var context = new HeroDbConnStr())
            {
                var data = context.Weapon.ToArray();
                WeaponNameRepeater.DataSource = data;
                WeaponNameRepeater.DataBind();
            }
        }

        protected void test_Click(object sender, EventArgs e)
        {
            var result = string.Empty;
            foreach (Control control in this.Controls)
            {
                result += control.ClientID + '\n';

                foreach (Control childControl in control.Controls)
                {
                    result += "    " + childControl.ClientID + '\n';
                }
            }

            TestPre.InnerText = result;
        }

        protected void CreateWeaponBtn_Click(object sender, EventArgs e)
        {
            var createWeapon = this.LoadControl(createWeaponPath) as CreateWeapon;
            createWeapon.ID = WeaponID;
            PH1.Controls.Clear();
            PH1.Controls.Add(createWeapon);
        }

        protected void CreateHeroBtn_Click(object sender, EventArgs e)
        {
            var createHero = this.LoadControl(createHeroPath) as CreateHero;
            createHero.ID = HeroID;
            PH1.Controls.Clear();
            PH1.Controls.Add(createHero);
        }

        protected void HeroNameRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName != "Delete")
            {
                return; 
            }

            var heroId = int.Parse((string)e.CommandArgument); 

            using (var context = new HeroDbConnStr())
            {
                var hero = context.Hero.SingleOrDefault(x => x.Id == heroId);
                if (hero != null)
                {
                    context.Hero.Remove(hero);
                    context.SaveChanges();

                    BindAllHeroNames();
                }
            }
        }
    }
}