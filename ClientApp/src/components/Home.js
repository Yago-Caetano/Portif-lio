import React, { Component } from 'react';
import Listing from './Listing';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = { projects: [],tags:[]};
  }

  componentDidMount() {
    this.getProjects();
  }

  render () {
    return (
      <div>
        <Listing data={this.state.projects} tags={this.state.tags}/>

      </div>
    );
  }

  getProjects = async()=>{
    var response = await fetch('Projects');
    const data = await response.json();

    response = await fetch('Tag')
    const TagsData = await response.json();

    this.setState({ projects: data,tags: TagsData});
    console.log(this.state.projects)
  }
}
