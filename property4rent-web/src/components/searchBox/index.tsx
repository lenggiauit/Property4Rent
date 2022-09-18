import { Form, Field, Formik, FormikHelpers, ErrorMessage } from 'formik';
import * as Yup from "yup";
import { useAppContext } from '../../contexts/appContext';
import { dictionaryList } from '../../locales';

interface FormValues {
    keywords: string; 
}
const SearchBox: React.FC  = ()=>{
    const { locale, } = useAppContext();
    let initialValues: FormValues = { keywords: '' };
    const validationSchema = () => {
        return Yup.object().shape({
            keywords: Yup.string().required(dictionaryList[locale]["RequiredField"]) 
        });
    }
    const handleOnSubmit = (values: FormValues, actions: FormikHelpers<FormValues>) => {
       

    }
    return(
    <> 
        <Formik initialValues={initialValues} onSubmit={handleOnSubmit} validationSchema={validationSchema} >
            <Form autoComplete={"off"} className="form-inline1">

            
            <div className="input-group mb-3">
            <Field type="text" className="form-control form-control-lg" name="keywords" placeholder="keywords" />
            {/* <ErrorMessage name="keywords" component="div" className="alert alert-field alert-danger" /> */}
                <div className="input-group-append">
                    
                    <button className="btn btn-outline-primary btn-lg" type="button">Search</button>
                </div>
            </div> 
            </Form>
        </Formik>
    
    </>)
}
export default SearchBox;

