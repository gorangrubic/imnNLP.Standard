using System;
using System.Collections.Generic;

namespace imbNLP.Toolkit.Space
{

    /// <summary>
    /// Model for a category
    /// </summary>
    /// <seealso cref="imbNLP.Toolkit.Space.SpaceTerm" />
    public class SpaceCategoryModel : SpaceDocumentModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceCategoryModel"/> class.
        /// </summary>
        public SpaceCategoryModel()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceCategoryModel"/> class.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="documents">The documents.</param>
        public SpaceCategoryModel(SpaceLabel label, IEnumerable<SpaceDocumentModel> documents)
        {
            name = label.name;
            Length = 0;

            foreach (SpaceDocumentModel doc in documents)
            {
                terms.MergeDictionary(doc.terms);
                Length += doc.Length;
            }
            Words = new Int32[Length];

            Int32 c = 0;
            foreach (SpaceDocumentModel doc in documents)
            {
                foreach (Int32 w in doc.Words)
                {
                    Words[c] = w;
                    c++;
                }

            }
        }



        /// <summary>
        /// Terms of the document
        /// </summary>
        /// <value>
        /// The terms.
        /// </value>
        //[XmlIgnore]
        //public TokenDictionary terms { get; set; } = new TokenDictionary();

    }

}