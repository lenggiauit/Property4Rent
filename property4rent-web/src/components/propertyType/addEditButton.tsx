import React, { useState } from "react";
import { PropertyType } from "../../services/models/propertyType";
import AddEditPropertyTypeModal from "./modals/addEdit";

type Props = {
    onAdded: (templateType?: PropertyType) => void,
}
const AddTemplateTypeButton: React.FC<Props> = ({ onAdded }) => {

    const [isShowModal, setIsShowModal] = useState<boolean>(false);
    const onAddNewHandler = (tempType?: PropertyType) => {
        setIsShowModal(false)
        onAdded(tempType);
    }
    return (<>
        {isShowModal && <AddEditPropertyTypeModal onClose={onAddNewHandler} />}
        <div className="col-6 col-lg-3">
            <a className="card shadow-1 hover-shadow-6" href="#" onClick={(e) => { e.preventDefault(); setIsShowModal(true) }} data-toggle="modal"  >
                <div className="card-body project-container d-flex text-center justify-content-center ">
                    <i className="bi bi-plus" style={{ fontSize: 42 }} ></i>
                </div>
            </a>
        </div>
    </>);
}



export default AddTemplateTypeButton;