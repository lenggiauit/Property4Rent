import { ErrorMessage, Field, Form, Formik, FormikHelpers } from "formik";
import React, { useState, useEffect } from "react";
import { useAppContext } from "../../../contexts/appContext"; 
import { Translation } from "../../translation";
import * as Yup from "yup";
import { dictionaryList } from "../../../locales";
import { AppSetting } from "../../../types/type";
import { ResultCode } from "../../../utils/enums";
import { useCreateEditPropertyTypeMutation } from "../../../services/property";
import PageLoading from "../../pageLoading";
import { PropertyType } from "../../../services/models/propertyType";
import * as uuid from "uuid";

let appSetting: AppSetting = require('../../../appSetting.json');

interface FormValues {
    id: string,
    name: string,
    description: string,
    isArchived: boolean
}

type Props = {
    propertyType?: PropertyType,
    onClose: (propertyType?: PropertyType) => void,
}

const AddEditPropertyTypeModal: React.FC<Props> = ({ propertyType, onClose }) => {

    const { locale } = useAppContext();
    const [PropertyType, setPropertyType] = useState<PropertyType | undefined>(propertyType);
    const [createEditPropertyType, createEditPropertyTypeStatus] = useCreateEditPropertyTypeMutation();
    const [archived, setArchived] = useState<boolean>(propertyType != null ? propertyType.isArchived : false);
    const onCancelHandler: React.MouseEventHandler<HTMLButtonElement> = (e) => {
        e.preventDefault();
        onClose();
    }

    const onCloseHandler: any = () => {
        onClose();
    }

    let initialValues: FormValues = { id: (propertyType == null ? uuid.NIL : propertyType.id), name: (propertyType != null ? propertyType?.name: ""), description: ( propertyType != null ? propertyType?.description: ""), isArchived: (propertyType != null ? propertyType.isArchived : false) };

    const validationSchema = () => {
        return Yup.object().shape({
            name: Yup.string().required(dictionaryList[locale]["RequiredField"]),
            description: Yup.string()
                .required(dictionaryList[locale]["RequiredField"])

        });
    }
    const handleOnSubmit = (values: FormValues, actions: FormikHelpers<FormValues>) => { 
        createEditPropertyType({ payload: { id: values.id, name: values.name, description: values.description, isArchived: archived } }); 
    }

    useEffect(() => {
        if (createEditPropertyTypeStatus.isSuccess && createEditPropertyTypeStatus.data.resultCode == ResultCode.Success) {
            onClose(createEditPropertyTypeStatus.data.resource);
        }
    }, [createEditPropertyTypeStatus])

    const handleArchivedclick: React.MouseEventHandler<HTMLLabelElement> = (e) => {
        setArchived(!archived);
    }

    // 
    return (<>
        {createEditPropertyTypeStatus.isLoading && <PageLoading />}
        <div className="modal fade show" role="dialog" aria-labelledby="addEditPropertyTypeModalLabel" aria-modal="true"  >
            <div className="modal-dialog modal-lg" role="document">
                <div className="modal-content">

                    <div className="modal-header">
                        <h5 className="modal-title" id="addEditPropertyTypeModalLabel">
                            {!propertyType && <Translation tid="CreateNewPropertyType" />}
                            {propertyType && <Translation tid="EditPropertyType" />}
                        </h5>
                        <button type="button" className="close" data-dismiss="modal" aria-label="Close" onClick={onCloseHandler} >
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                    <div className="modal-body pb-0 pt-5"> 
                        <Formik initialValues={initialValues} 
                        onSubmit={handleOnSubmit} 
                        validationSchema={validationSchema} 
                        validateOnChange={false}  >
                            {({ values, errors, touched }) => (
                                <Form autoComplete="off">
                                    <div className="form-group">
                                        <Field type="hidden" name="id" />
                                        <Field type="text" className="form-control" name="name" placeholder="name" />
                                        <ErrorMessage
                                            name="name"
                                            component="div"
                                            className="alert alert-field alert-danger"
                                        />
                                    </div>

                                    <div className="form-group">
                                        <Field type="textarea" as="textarea" row={7} className="form-control" name="description" placeholder="description" />
                                        <ErrorMessage
                                            name="description"
                                            component="div"
                                            className="alert alert-field alert-danger"
                                        />
                                    </div>

                                    <div className="form-group">
                                        <div className="custom-control custom-checkbox">
                                            <Field type="checkbox" className="custom-control-input" name="isArchived" checked={archived} />
                                            <label className="custom-control-label" onClick={handleArchivedclick} ><Translation tid="archived" /></label>
                                        </div>
                                    </div> 
                                    <div className="modal-footer border-0 pr-0 pl-0">
                                        <button type="button" className="btn btn-secondary" onClick={onCancelHandler} data-dismiss="modal"><Translation tid="btnClose" /></button>
                                        <button type="submit" className="btn btn-primary" >
                                            {propertyType && <Translation tid="btnSave" />}
                                            {!propertyType && <Translation tid="btnCreate" />}
                                        </button>
                                    </div>
                                </Form>
                            )}
                        </Formik>
                    </div>
                </div>
            </div>
        </div>
    </>);
}

export default AddEditPropertyTypeModal;