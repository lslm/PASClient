using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASClient.model
{
    class Relation
    {
        public string RelationName { get; set; }
        public string Classes { get; set; }
        public List<Instance> Instances { get; set; }

        public Relation()
        {
            RelationName = "";
            Classes = "";
            Instances = new List<Instance>();
        }

        public string getNewRelation()
        {
            string relation = "";

            foreach (Instance instance in Instances)
            {
                relation += instance.getNewInstance() + "\r\n";
            }

            return relation;
        }
    }
}

/*
 * @relation train
 *
 *   @attribute Document string
 *   @attribute class {yes,no}
 *
 *   @data
 *   "The price of crude oil has increased significantly", yes
 *   "Demand for crude oil outstrips supply", yes
 *   "Some people do not like the flavor of olive oil", no
 *   "The food was very oily", no
 *   "Crude oil is in short supply", yes
 *   "Use a bit of cooking oil in the frying pan", no
 */
