import React from "react";

const Tags = (props) =>{

    return(
        <div>
            {
                props.itemTags.map(t =>{
                    var tagFound = props.tagsStored.filter((tag)=>{if(tag.id === t.idTag){return true}else{return false}})
                    return(<div id="tag-Item">{tagFound[0].Nome}</div>)
                })
            }
        </div>
    )
}

export default Tags;