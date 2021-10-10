import React from "react";
import Tags from "./Tags";
import { useHistory } from 'react-router-dom';




const ListItem = (props)=>{

    const history = useHistory()

    const handleCardClick = (id) =>
    {
        history.push(`/view-project/${id}`)
    }

    return(
        <div className="card m-1 shadow-sm" style={{width:'45%'}} onClick={()=>handleCardClick(props.id)}>
            <div className="card-body">
                {
                    props.data.Fotos  && props.data.Fotos.length > 0 ? (<figure><img className="card-img-top " src={`data:image/png;base64,${props.data.Fotos[0].Foto}`}></img></figure>):(<></>)
                }
                {
                    props.data.Nome ? (<div className="card-title">{props.data.Nome}</div>) : (<></>)
                }
                {
                    props.data.Descricao ? (<div>{props.data.Descricao}</div>) : (<></>)
                }
                {
                    props.data.Tags && props.data.Tags.length > 0 ? (<Tags itemTags={props.data.Tags} tagsStored={props.tags}/>) : (<></>)
                }
            </div>

        </div>
    )
}

export default ListItem