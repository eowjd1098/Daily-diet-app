using System.Runtime.Serialization;

namespace Service
{
    [DataContract]
    public class FoodNutrient
    {
        [DataMember]
        string name;    //이름
        [DataMember]
        byte[] img;     //사진
        [DataMember]
        int kcal;       //열량
        [DataMember]
        double cho;     //탄수화물
        [DataMember]
        double fat;     //지방
        [DataMember]
        double protein; //단백질
        [DataMember]
        double na;      //나트륨
        
        public FoodNutrient() { }

        public FoodNutrient(string name, int kcal, double cho, double fat, double protein, double na)
        {
            this.name = name;
            this.kcal = kcal;
            this.cho = cho;
            this.fat = fat;
            this.protein = protein;
            this.na = na;           
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public byte[] IMG
        {
            get { return img; }
            set { img = value; }
        }

        public int Kcal
        {
            get { return kcal; }
            set { kcal = value; }
        }

        public double Cho
        {
            get { return cho; }
            set { cho = value; }
        }

        public double Fat
        {
            get { return fat; }
            set { fat = value; }
        }

        public double Protein
        {
            get { return protein; }
            set { protein = value; }
        }

        public double Na
        {
            get { return na; }
            set { na = value; }
        }
               
    }
}