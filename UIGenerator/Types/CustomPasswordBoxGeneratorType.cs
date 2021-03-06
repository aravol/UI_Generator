﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmptyKeys.UserInterface.Designer;

namespace EmptyKeys.UserInterface.Generator.Types
{
    /// <summary>
    /// Implements Custom Password Box control generator with binding support for Password property
    /// </summary>
    public class CustomPasswordBoxGeneratorType : TextBoxGeneratorType
    {
        /// <summary>
        /// Gets the type of the xaml.
        /// </summary>
        /// <value>
        /// The type of the xaml.
        /// </value>
        public override Type XamlType
        {
            get
            {
                return typeof(PasswordBox);
            }
        }

        /// <summary>
        /// Generates code
        /// </summary>
        /// <param name="source">The dependence object</param>
        /// <param name="classType">Type of the class.</param>
        /// <param name="initMethod">The initialize method.</param>
        /// <param name="generateField">if set to <c>true</c> [generate field].</param>
        /// <returns></returns>
        public override CodeExpression Generate(DependencyObject source, CodeTypeDeclaration classType, CodeMemberMethod initMethod, bool generateField)
        {
            CodeExpression fieldReference = base.Generate(source, classType, initMethod, generateField);

            PasswordBox passBox = source as PasswordBox;
            CodeComHelper.GenerateField<char>(initMethod, fieldReference, source, PasswordBox.PasswordCharProperty);
            CodeComHelper.GenerateField<string>(initMethod, fieldReference, source, PasswordBox.PasswordProperty);

            return fieldReference;
        }
    }
}
