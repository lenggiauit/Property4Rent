import React from "react";
import { PropertyType } from "../../services/models/propertyType";

type Props = {
    propertyType: PropertyType,
    onSelected: (propertyType: PropertyType) => void,
}

const propertyTypeItem: React.FC<Props> = ({ propertyType, onSelected }) => {

    return (<>
        <div className="col-6 col-lg-3">
            <a className="card shadow-1 hover-shadow-6" href="#" onClick={(e) => { e.preventDefault(); onSelected(propertyType) }}   >
                <div className="card-body template-type-item-container">
                    <h6 className="mb-0">{propertyType.name}</h6>
                    <div>
                        <small className="small-4 ls-2">{propertyType.description.length > 42 ? propertyType.description.substring(0, 42) : propertyType.description}</small>
                    </div>
                </div>
            </a>
        </div>
    </>)
}

export default propertyTypeItem;