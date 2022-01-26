import React, { useEffect } from 'react';
import Card from '@mui/material/Card';
import Grid from '@mui/material/Grid';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import { useLocation } from 'react-router-dom';
import NavbarComponent from '../../components/NavbarComponent';
import { useDispatch } from 'react-redux';
import { useTypedSelector } from '../../hooks/useTypeSelector';
import { getClickedBlogPost } from '../../store/actionCreators/blogPostCreator';
import Container from '@mui/material/Container';
import Authentication from '../../helpers/Authentication';
import { Box, useMediaQuery, useTheme } from '@material-ui/core';
import DropDownMenu from './DropDownMenu';
import MenuComponent from './MenuComponent';

export default function DetailedBlogPostPage() {
  const theme = useTheme();
  const dispatch = useDispatch();
  const { blogPost } = useTypedSelector((state) => state.blogPosts);
  const blogPostId: string = useLocation().state as string;
  const isLoggedIn = Authentication.getUser().id != 'null' ? true : false; //Check if user is logged in if userID is null or not
  const isMobile = useMediaQuery(theme.breakpoints.down('sm'));

  useEffect(() => {
    dispatch(getClickedBlogPost(blogPostId));
    blogPost.content;
  }, [dispatch]);

  const DisplayMore = () => {
    if (isMobile) return <></>;
    return <MenuComponent blogPostId={blogPostId} blogPost={blogPost} />;
  };

  return (
    <>
      <NavbarComponent />
      <Container
        component='main'
        sx={{
          display: 'flex',
          justifyContent: 'center',
        }}
        maxWidth='xl'
      >
        <Grid container>
          <Card
            sx={{
              boxShadow: 'none',
              borderRadius: '0',
            }}
          >
            <Box
              style={{
                backgroundImage: `url(${blogPost.imageSrc})`,
                display: 'flex',
                alignItems: 'flex-end',
                justifyContent: 'flex-end',
              }}
              height='280px'
            >
              {isMobile && (
                <DropDownMenu blogPostId={blogPostId} blogPost={blogPost} />
              )}
            </Box>
            <CardContent>
              <CardActions
                sx={{
                  display: 'flex',
                  justifyContent: 'space-between',
                  alignItems: 'baseline',
                }}
              >
                <Typography
                  gutterBottom
                  variant='h5'
                  component='div'
                  sx={{ display: 'flex', justifyContent: 'center' }}
                >
                  {blogPost.header}
                </Typography>

                {isLoggedIn && <DisplayMore />}
              </CardActions>

              <Typography
                variant='body2'
                color='text.secondary'
                sx={{ whiteSpace: 'pre-line' }}
              >
                {blogPost.content}
              </Typography>
            </CardContent>
          </Card>
        </Grid>
      </Container>
    </>
  );
}
