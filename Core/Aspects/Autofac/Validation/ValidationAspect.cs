using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //aspect : methodun başında sonunda ortasında çalışacak method
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);          // çalışma esnasıunda reflection ile nesne oluştur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];            // birden fazla tip alabilir bu fonk. onun 0. tipini yakala
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);   // sonra fonksiyona bak gelen tiple parametre tip aynı ise işlemi yap 
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
