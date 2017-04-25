import React from 'react';
import injectSheet from 'react-jss' 

const styles = {
  '@font-face': {
    fontFamily: 'Roboto',
    src: "url('https://fonts.googleapis.com/css?family=Roboto')",
  },
  container: {
    fontFamily: 'Roboto, sans-serif',
    display: 'grid',
    gridTemplateRows: '50% 50%',
    height: '100%',
    width: '100%'
  },
  title: {
    fontSize: '1.5em'
  },
  subTitle: {
    fontSize: '1em'
  },
  tagline: {
    fontSize: '0.9em'
  },
  metadata: {
    fontSize: '0.9em',
    fontWeight: 200,
    fontStyle: 'oblique'
  },
  top: {
    gridRow: 1,
    alignSelf: 'start'
  },
  bottom: {
    gridRow: 2,
    alignSelf: 'end'
  }
}

const InfoDisplay = ({classes, title, subtitle, tagline, metadata, stats}) => (
  <div className={classes.container}>
    <div className={classes.top}>
      <div className={classes.title}>{title || ""}</div>
      <div className={classes.subTitle}>{subtitle || ""}</div>
      <div className={classes.tagline}>{tagline || ""}</div>
      {(metadata || []).map(m => <div className={classes.metadata}>{m || ""}</div>)}
    </div>
    <div className={classes.bottom}>
      {(stats || []).map(s => <div className={classes.stats}>{s || ""}</div>)}
    </div>
  </div>
)

export default injectSheet(styles)(InfoDisplay)