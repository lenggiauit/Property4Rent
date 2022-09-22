import React, { useEffect, useState } from "react";
import { Translation } from "../translation";
import { useGetPropertyTypesMutation } from "../../services/property";
import { AppSetting, MetaData, Paging } from "../../types/type";
import Pagination from "../pagination"; 
import PropertyTypeItem from "./item";
import { v4 } from "uuid";
import PageLoading from "../pageLoading";
import LocalSpinner from "../localSpinner";
import AddProjectButton from "./addEditButton";
import { hasPermission } from "../../utils/functions";
import { PropertyType } from "../../services/models/propertyType";
import { PermissionKeys } from "../../utils/constants";
import AddEditPropertyTypeModal from "./modals/addEdit";
const appSetting: AppSetting = require('../../appSetting.json');

const PropertyTypeList: React.FC = () => {
    const [isShowModal, setIsShowModal] = useState<boolean>(false);
    // get team list
    const [getPropertyTypesList, getPropertyTypesStatus] = useGetPropertyTypesMutation();
    const [metaData, setMetaData] = useState<MetaData>({ paging: { index: 1, size: appSetting.PageSize } });
    const [pagingData, setPagingData] = useState<Paging>({ index: 1, size: appSetting.PageSize });
    const [totalRows, setTotalRows] = useState<number>(0);
    const [isArchived, setIsArchived] = useState<boolean>(false);
    const [PropertyTypeList, setPropertyTypeList] = useState<PropertyType[]>([]);

    const [selecttedPropertyType, setSelecttedPropertyType] = useState<PropertyType>();
    const pagingChangeEvent: any = (p: Paging) => {

        let mp: Paging = {
            index: p.index,
            size: p.size
        }
        setPagingData(mp);
    }
    useEffect(() => {
        let md: MetaData = {
            paging: pagingData
        }
        setMetaData(md);
    }, [pagingData]);


    useEffect(() => {
        getPropertyTypesList({ payload: { isArchived: isArchived }, metaData: metaData });
    }, [metaData, isArchived]);

    useEffect(() => {
        if (getPropertyTypesStatus.isSuccess && getPropertyTypesStatus.data.resource != null) {
            let data = getPropertyTypesStatus.data.resource;
            if (data.length > 0) {
                setTotalRows(data[0].totalRows);
            }
            else {
                setTotalRows(0);
            }
            setPropertyTypeList(data);
        }
    }, [getPropertyTypesStatus]);

    const onEditHandler = (tempType: PropertyType) => {
        setSelecttedPropertyType(tempType);
        setIsShowModal(true);
    }

    const onCloseHandler = (tempType?: PropertyType) => {
        setIsShowModal(false);
        getPropertyTypesList({ payload: { isArchived: isArchived }, metaData: metaData });
        // if (tempType != null) {
        //     let exitTemp = PropertyTypeList.findIndex(t => t.id == tempType.id);
        //     if (exitTemp == -1) {
        //         var l = PropertyTypeList.filter(t => t);
        //         l.push(tempType);
        //         setPropertyTypeList(l);
        //     }
        //     else {
        //         var l = PropertyTypeList.filter(t => t.id != tempType.id);
        //         if ((isArchived && tempType.isArchived) || !isArchived && !tempType.isArchived) {
        //             l.push(tempType);
        //         }

        //         setPropertyTypeList(l);
        //     }
        // }
    }



    return (<>
        {getPropertyTypesStatus.isLoading && <PageLoading />}
        {isShowModal && <AddEditPropertyTypeModal propertyType={selecttedPropertyType} onClose={onCloseHandler} />}
        <section className="section overflow-hidden bg-gray">
            <div className="container">
                <header className="section-header mb-0">
                    <h2><Translation tid="PropertyTypesList" /></h2>
                    <hr />
                </header>

                <div data-provide="shuffle">
                    <ul className="nav nav-center nav-bold nav-uppercase nav-pills mb-7 mt-0" data-shuffle="filter">
                        <li className="nav-item">
                            <a className={"nav-link " + (!isArchived ? "active" : "")} href="#" data-shuffle="button" onClick={() => { setIsArchived(false) }}><Translation tid="all" /></a>
                        </li>
                        <li className="nav-item">
                            <a className={"nav-link " + (isArchived ? "active" : "")} href="#" data-shuffle="button" onClick={() => { setIsArchived(true) }} data-group="bag"><Translation tid="archived" /></a>
                        </li>
                    </ul>
                    <div className="row gap-y gap-2" data-shuffle="list">
                        {hasPermission(PermissionKeys.CreateEditPropertyType) && !isArchived && <AddProjectButton onAdded={onCloseHandler} />}
                        {PropertyTypeList.map(p => <PropertyTypeItem key={v4().toString()} propertyType={p} onSelected={onEditHandler} />)}
                    </div>

                    <div className="mt-7">
                        <Pagination totalRows={totalRows} pageChangeEvent={pagingChangeEvent} />
                    </div>
                </div>
            </div>
        </section>
    </>)
}

export default PropertyTypeList;

